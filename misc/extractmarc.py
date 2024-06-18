# extractmarc.py - script to analyze and extract MARC records.
# This is to create a subset of MARC records to test a Koha ILS system.
# Mark Riordan  18-JUN-2024

import random
import argparse
from pymarc import MARCReader, MARCWriter

# Set up command-line argument parsing
parser = argparse.ArgumentParser(description='Analyze and extract MARC records.')
parser.add_argument('-i', '--input', default='/Users/mrr/Downloads/marc_marygrove/marygrovecollegelibrary.full.D20191108.T213022.internetarchive2nd_REPACK.mrc', help='Input file')
parser.add_argument('-o', '--output', default='random_records.mrc', help='Output file')
args = parser.parse_args()

nRecs = 0
dewey_counts = {str(i).zfill(2): 0 for i in range(100)}
condition = "all"
infile = args.input
outfile = args.output
with open(infile, 'rb') as fh, open(outfile, 'wb') as out_fh:
    reader = MARCReader(fh)
    writer = MARCWriter(out_fh)
    for record in reader:
        if '082' in record and record['082']['a']:
            dewey = record['082']['a']
            # if len(dewey) >= 2:
            #     dewey_prefix = dewey[:2]
            #     if dewey_prefix in dewey_counts:
            #         dewey_counts[dewey_prefix] += 1
            # Select random records to write to the output file.
            if True or random.random() < 0.01:
                writer.write(record)
                nRecs += 1
            # print('Title:', record.title())
            # print('Author:', record.author())
            # print('Subjects:', record.subjects())
            # print('ISBN:', record.isbn())
            # print('LCCN:', record['010'])
            # print('OCLC:', record['035'])
            # print('Pub Date:', record.pub_date())
            # print('Physical Desc:', record.physical_description())
            # print('Notes:', record.notes())
            # print('URLs:', record.urls())
            # print('Record ID:', record['001'])
            # print('Record Length:', len(record.as_marc()))
            #print('Record:', record)
            #print('---')
            # print (dewey)
            # if nRecs > 7:
            #     break

# Write dewey_counts to a new Python file
# with open('dewey_counts.py', 'w') as f:
#     f.write('dewey_counts = ' + str(dewey_counts))

# for prefix, count in dewey_counts.items():
#     print(f'Dewey numbers starting with {prefix}: {count}')

print('Number of records ' + condition + ':', nRecs)
