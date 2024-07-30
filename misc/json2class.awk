# json2class.awk - Convert JSON to C# class
# Mark Riordan  2024-07-29
# Usage: awk95 -f json2class.awk AddedPatronOut.json > AddedPatronOut.cs
# Create a class from JSON that looks like:
# {
#  "address": "2250 Main St",
#  "address2": "Apt UO2",
#  "anonymized": false,
#  "autorenew_checkouts": false,
#  "cardnumber": "43237602245896",
#  "category_id": "AD",
#  "city": "Springfield",
#  "country": "US",
#  "date_enrolled": "2024-07-29T22:01:22",
#  "date_of_birth": "2000-07-21",
#  "date_renewed": null,
#  "email": "fred.smithIR3WY@gmail.com",
#  "expiry_date": "2027-07-29T22:01:22",
#  "firstname": "Xerxes",
#  "incorrect_address": false,
#  "last_seen": null,
#  "library_id": "FRL",
#  "opac_notes": "",
#  "patron_card_lost": false,
#  "patron_id": 13,
#  "phone": "555-555-2285",
#  "postal_code": "37960",
#  "privacy": 1,
#  "privacy_guarantor_fines": false,
#  "protected": false,
#  "restricted": false,
#  "staff_notes": "",
#  "state": "IL",
#  "surname": "SmithVWS",
#  "updated_on": null,
#  "userid": "43237602245896"
# }

{
	line = $0
	if(length(line) > 1) {
		name = $1
		sub(/^"/, "", name)
		sub(/":/, "", name)
		sub(/,$/, "", name)

		value = $2
		type = "unknown"
		sub(/,$/, "", value)
		if(substr(value, 1, 1) == "\"" || name=="cardnumber" || name=="userid" ||
		  name=="postal_code" || name=="date_of_birth") {
			type = "string"
			sub(/^"/, "", value)
			sub(/"$/, "", value)
		} else if(value == "true" || value == "false") {
			type = "bool"
		} else if(value ~ /^[0-9]+$/) {
			type = "int"
		} else if(value ~ /^[0-9]+\.[0-9]+$/) {
			type = "double"
		} else if(value ~ /^[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}$/) {
			type = "DateTime"
		} else if(value == "null") {
			type = "null"
		}

		printf("        public %s %s { get; set; }\n", type, name)
	}
}
