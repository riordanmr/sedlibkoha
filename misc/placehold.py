# placehold.py - Script to perform operations related to holds on a Koha ILS.
# We can place a hold:
# We use the Koha REST API to list items, and then try place a hold
# on each item in the list until we find one that is available. 
# We can also list items on hold.
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
# KOHA_URL_STAFF is the base staff URL of the Koha instance, 
# e.g., "http://sedkoha1-intra.csproject.org".
base_url = os.getenv("KOHA_URL_STAFF")
username = os.getenv("KOHA_USERNAME")
password = os.getenv("KOHA_PASSWORD")

class Settings:
    def __init__(self, loc, num, action):
        self.loc = loc
        self.num = num
        self.action = action

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

def list_items():
    global base_url, username, password
    # First, list all biblio records on hold. Unfortunately, the Koha API
    # does not provide a way to list items on hold, so once we have a list
    # of biblio records, we have to get the items for each biblio record.
    holds_url = base_url + "/api/v1/holds"
    page = 0
    per_page = 20
    headers = {
        "Accept": "application/json"
    }
    biblio_list = []
    # Loop, requesting pages of holds.
    while True:
        page += 1
        url = holds_url + f"?_page={page}&_per_page={per_page}"
        response = requests.get(url, auth=HTTPBasicAuth(username, password), headers=headers)
        if response.status_code > 100 and response.status_code < 400:
            holds = response.json()
            if len(holds) == 0:
                break
            for hold in holds:
                biblio_list.append(hold["biblio_id"])
        else:
            print("Failed to get holds: status code", response.status_code)
            print("Response content:", response.content)
            break
    #print("Biblio records on hold:", biblio_list)
    # Now, for each biblio record, get an item that would satisfy the hold for that biblio.
    for biblio_id in biblio_list:
        items_url = base_url + f"/api/v1/biblios/{biblio_id}/items"
        response = requests.get(items_url, auth=HTTPBasicAuth(username, password), headers=headers)
        if response.status_code > 100 and response.status_code < 400:
            items = response.json()
            for item in items:
                barcode = item["external_id"]
                print(barcode)
                # We only need one item per biblio record, so break after the first.
                break
        else:
            print("Failed to get items for hold: status code", response.status_code)
            print("Response content:", response.content)
            break

def parse_args():
    # Initialize the argument parser
    parser = argparse.ArgumentParser(description='Process command line arguments.')
    # Add the 'loc' command line argument
    parser.add_argument('--loc', type=str, default='local', choices=['local', 'remote'],
                        help='Location setting: "local" or "remote"')
    parser.add_argument('--num', type=int, default=1,
                        help='Number of items to place holds on')
    parser.add_argument('--action', type=str, default='place', choices=['place', 'list'],
                        help='Action: "place" or "list"')
    
    # Parse the command line arguments
    args = parser.parse_args()

    return Settings(loc=args.loc, num=args.num, action=args.action)

def main():
    initialize()
    settings = parse_args()
    if settings.action == "list":
        list_items()
    elif settings.action == "place":
        num_held = find_and_hold_items(settings)
        print(f"Holds placed on {num_held} items.")
    else:
        print("Invalid action:", settings.action)
        sys.exit(1)

main()
