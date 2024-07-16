# placehold.py - Script to place a hold on an item on a Koha ILS.
# We use the Koha REST API to list items, and then try place a hold
# on each item in the list until we find one that is available. 
# This is for testing drivecheckin.js; previously, I was placing holds
# using the human web interface, but that was slow.
#
# Mark Riordan  16-JUL-2024

import os
import requests # type: ignore
from requests.auth import HTTPBasicAuth # type: ignore
import sys

# base_url is the URL of the Koha instance, with the /api/v1 suffix.
base_url = os.getenv("KOHA_URL_STAFF")
username = os.getenv("KOHA_USERNAME")
password = os.getenv("KOHA_PASSWORD")

def initialize():
    global base_url, username, password
    if base_url is None or username is None or password is None:
        print("Please set the KOHA_URL_STAFF, KOHA_USERNAME, and KOHA_PASSWORD environment variables.")
        sys.exit(1)

def place_hold(item):
    global base_url, username, password
    url = base_url + "/api/v1/holds"
    headers = {
        "Content-Type": "application/json"
    }
    data = {
        "biblio_id": item["biblio_id"],
        "patron_id": 2,
        "pickup_library_id": "RPL"
    }
    response = requests.post(url, auth=HTTPBasicAuth(username, password), headers=headers, json=data)
    if response.status_code > 100 and response.status_code < 400:
        print("Hold placed on item", item["biblio_id"], "with barcode", item["external_id"])
        return True
    else:
        print("status code", response.status_code)
        response_content = response.content.decode('utf-8')
        print("Response content:", response_content)
        return False
    
def find_available_item():
    global base_url, username, password
    # Note: We only retrieve one page of items. If all of them are unavailable,
    # we will fail to place a hold. 
    # ToDo: Add pagination.
    url = base_url + "/api/v1/items"
    headers = {
        "Accept": "application/json"
    }
    response = requests.get(url, auth=HTTPBasicAuth(username, password), headers=headers)
    if response.status_code > 100 and response.status_code < 400:
        items = response.json()
        for item in items:
            if item["holds_count"] is None:
                # Unfortunately, most or all items have holds_count = null. 
                # This would seem to be a bug in Koha. So we have to try to place
                # the hold and if it fails, try the next item.
                print("Found available item:", item["biblio_id"], "with barcode", item["external_id"])
                if place_hold(item):
                    return item
                else:
                    print("Failed to place hold on item; will try with next.")
        print("No available items found.")
    else:
        print("Failed to get items: status code", response.status_code)
        print("Response content:", response.content)
    return None

def main():
    initialize()
    item = find_available_item()

main()
