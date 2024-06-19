# additems.py - Update a Koha instance using the REST API.
# For each biblio record (which abstractly represents a book but does not
# reflect an item actually owned by the library), we extract its 
# suggested Dewey Decimal Classification number and add an "item" 
# to the record. The item represents a physical copy of the book,
# and includes the Dewey number (we always use the one suggested
# in the biblio), a fake barcode, and other information.
#
# Mark Riordan  19-JUN-2024

import os
import requests # type: ignore
from requests.auth import HTTPBasicAuth # type: ignore
import sys
import time

nextBarcode = ""

def save_next_barcode(next_barcode):
    with open("nextbarcode.txt", "w") as file:
        file.write(str(next_barcode))

def read_next_barcode():
    with open("nextbarcode.txt", "r") as file:
        next_barcode = int(file.read())
    return next_barcode

def get_username_and_password():
    username = os.getenv("KOHA_USERNAME")
    password = os.getenv("KOHA_PASSWORD")
    if username is None or password is None:
        print("Please set the KOHA_USERNAME and KOHA_PASSWORD environment variables.")
        sys.exit(1)
    return username, password

def get_biblio_record(recNum):
    url = "https://sedkoha1-intra.csproject.org/api/v1/biblios/" + str(recNum)
    headers = {
        "Accept": "application/marc-in-json"
    }
    username, password = get_username_and_password()
    response = requests.get(url, auth=HTTPBasicAuth(username, password), headers=headers)
    if response.status_code > 100 and response.status_code < 400:
        # print(f"getBiblioRecord request {recNum} was successful.")
        # print("Response content:", response.content)
        return response.json()
    else:
        print(f"getBiblioRecord request {recNum} failed: status code", response.status_code)
        print("Response content:", response.content)
        return None

def extract_marc_field(jsonRecord, marc_field):
    if "fields" in jsonRecord:
        fields = jsonRecord["fields"]
        for field in fields:
            if marc_field in field:
                fld = field[marc_field]
                if "subfields" in fld:
                    subfields = fld["subfields"]
                    for subfield in subfields:
                        if "a" in subfield:
                            return subfield["a"]
    return None

def extract_dewey_number(jsonRecord):
    return extract_marc_field(jsonRecord, "082")

def extract_title(jsonRecord):
    return extract_marc_field(jsonRecord, "245")

def add_item_for_biblio(recNum, deweyNumber):
    global nextBarcode
    url = "https://sedkoha1-intra.csproject.org/api/v1/biblios/" + str(recNum) + "/items"
    headers = {
        "Content-Type": "application/json"
    }
    username, password = get_username_and_password()
    data = {
        "callnumber": deweyNumber,
        "external_id": nextBarcode,
        "holding_library_id": "FRL",
        "home_library_id": "FRL",
        "item_type_id": "BK",
        "location": "GEN",
        "permanent_location": "GEN"
    }
    response = requests.post(url, auth=HTTPBasicAuth(username, password), headers=headers, json=data)
    if response.status_code > 100 and response.status_code < 400:
        print(f"Item Add OK for bib {recNum} DD {deweyNumber} barcode {nextBarcode}.")
        #print("Response content:", response.content)
        nextBarcode += 1
        return response.json()
    else:
        print("Item Add request failed: status code", response.status_code)
        print("Response content:", response.content)
        return None

def process_biblio(recNum):
    biblioRecord = get_biblio_record(recNum)
    if biblioRecord is not None:
        # print ("Biblio Record:", biblioRecord)
        deweyNumber = extract_dewey_number(biblioRecord)
        title = extract_title(biblioRecord)
        if deweyNumber is not None:
            print("Dewey for biblio", recNum, '"' + title, '":', deweyNumber)
            result = add_item_for_biblio(recNum, deweyNumber)
            if result is not None:
                return True
            else:
                return False
        else:
            print("No Dewey number found.")
            return False
    else:
        print(f"Biblio record {recNum} not found.")
        return False


def main():
    global nextBarcode
    start_time = time.perf_counter()
    nextBarcode = read_next_barcode()
    # The biblio record numbers start at 1 and go up to the number of records.
    start_recNum = 165
    num_to_process = 200
    num_processed = 0
    for recNum in range(start_recNum, start_recNum + num_to_process):
        if process_biblio(recNum):
            num_processed += 1
        else:
            break
    save_next_barcode(nextBarcode)
    end_time = time.perf_counter()
    elapsed_time = end_time - start_time
    if elapsed_time == 0.0:
        elapsed_time = 0.0001
    print(f"Processed {num_processed} recs in {elapsed_time:.2f} seconds; avg {num_processed/elapsed_time:.2f} recs/sec.")
main()
