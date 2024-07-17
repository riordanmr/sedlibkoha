# placehold.py - Script to place a hold on an item on a Koha ILS.
# We use the Koha REST API to list items, and then try place a hold
# on each item in the list until we find one that is available. 
# This is for testing drivecheckin.js; previously, I was placing holds
# using the human web interface, but that was slow.
#
# Mark Riordan  16-JUL-2024

import argparse
import os
import requests # type: ignore
from requests.auth import HTTPBasicAuth # type: ignore
import sys

# base_url is the URL of the Koha instance, with the /api/v1 suffix.
base_url = os.getenv("KOHA_URL_STAFF")
username = os.getenv("KOHA_USERNAME")
password = os.getenv("KOHA_PASSWORD")

class Settings:
    def __init__(self, loc, num):
        self.loc = loc
        self.num = num

def initialize():
    global base_url, username, password
    if base_url is None or username is None or password is None:
        print("Please set the KOHA_URL_STAFF, KOHA_USERNAME, and KOHA_PASSWORD environment variables.")
        sys.exit(1)

def place_hold(item, settings):
    global base_url, username, password
    if settings.loc == "local":
        library_id = "FRL"
    else:
        library_id = "RPL"

    url = base_url + "/api/v1/holds"
    headers = {
        "Content-Type": "application/json"
    }
    data = {
        "biblio_id": item["biblio_id"],
        "patron_id": 2,
        "pickup_library_id": library_id
    }
    response = requests.post(url, auth=HTTPBasicAuth(username, password), headers=headers, json=data)
    if response.status_code > 100 and response.status_code < 400:
        print("Hold placed on item", item["biblio_id"], "with barcode", item["external_id"])
        return True
    else:
        if response.status_code != 403:
            print("status code", response.status_code)
            response_content = response.content.decode('utf-8')
            print("Response content:", response_content)
        return False
    
def find_and_hold_items(settings):
    global base_url, username, password
    items_url = base_url + "/api/v1/items"
    headers = {
        "Accept": "application/json"
    }

    num_held = 0
    page = 0
    per_page = 20
    # Loop, requesting pages of items until we find one that is available.
    while True:
        page += 1
        url = items_url + f"?_page={page}&_per_page={per_page}"
        response = requests.get(url, auth=HTTPBasicAuth(username, password), headers=headers)
        if response.status_code > 100 and response.status_code < 400:
            items = response.json()
            for item in items:
                if item["holds_count"] is None:
                    # Unfortunately, most or all items have holds_count = null. 
                    # This would seem to be a bug in Koha. So we have to try to place
                    # the hold and if it fails, try the next item.
                    #print("Found available item:", item["biblio_id"], "with barcode", item["external_id"])
                    if place_hold(item, settings):
                        num_held += 1
                        if num_held >= settings.num:
                            return num_held
                    else:
                        #print("Failed to place hold on item; will try with next.")
                        pass
            print("No available items in this page; will request the next page.")
        else:
            print("Failed to get items: status code", response.status_code)
            print("Response content:", response.content)
    
def parse_args():
    # Initialize the argument parser
    parser = argparse.ArgumentParser(description='Process command line arguments.')
    # Add the 'loc' command line argument
    parser.add_argument('--loc', type=str, default='local', choices=['local', 'remote'],
                        help='Location setting: "local" or "remote"')
    parser.add_argument('--num', type=int, default=1,
                        help='Number of items to place holds on')
    
    # Parse the command line arguments
    args = parser.parse_args()

    return Settings(loc=args.loc, num=args.num)

def main():
    initialize()
    settings = parse_args()
    num_held = find_and_hold_items(settings)
    print(f"Holds placed on {num_held} items.")

main()
