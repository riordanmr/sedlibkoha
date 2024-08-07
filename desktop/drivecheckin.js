// Script to use Puppeteer to automate a browser to trap holds
// using the Koha ILS.
// We scan the barcode of an item that has a hold on it into this script,
// and the script instructs the browser to process the hold appropriately.
// Mark Riordan  2024-06-19
const puppeteer = require('puppeteer');
const readline = require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
});
const net = require('net');

var kohaUrlStaffBase, kohaUsername, kohaPassword;
var pageAwaitingPickup;
var client;

function getUserInput(query) {
    return new Promise(resolve => readline.question(query, resolve));
}

async function getSettings() {
    // Environment variable KOHA_URL_STAFF must be set to the base URL of the Koha staff interface;
    // e.g., https://staff-yavapaiaz.bywatersolutions.com
    // Environment variables KOHA_USERNAME and KOHA_PASSWORD may be set to the username and password.
    console.log("You may set env vars KOHA_URL_STAFF, KOHA_USERNAME, and KOHA_PASSWORD.");
    kohaUrlStaffBase = process.env.KOHA_URL_STAFF;
    if (kohaUrlStaffBase == null) {
        // The env var is not set, so use the default.
        kohaUrlStaffBase = "https://staff-yavapaiaz.bywatersolutions.com";
        console.log("KOHA_URL_STAFF not set, so using " + kohaUrlStaffBase);
    }
    kohaUsername = process.env.KOHA_USERNAME;
    if (kohaUsername == null) {
        kohaUsername = await getUserInput('Enter Koha username: ');
    }
    kohaPassword = process.env.KOHA_PASSWORD;
    if (kohaPassword == null) {
        kohaPassword = await getUserInput('Enter Koha password: ');
    }
}

// Returns an array of the browser and the page.
async function startBrowserAndLogin(url) {
    const browser = await puppeteer.launch({ headless: false });
    const page = await browser.newPage();

    await page.goto(url);

    await page.type('#userid', kohaUsername);
    await page.type('#password', kohaPassword);
    await Promise.all([
        page.click('#submit-button'),
        page.waitForNavigation({ waitUntil: 'networkidle0' })
    ]);
    return [browser, page];
}

async function run() {
    var browserMain;
    var bConnectedToPrintHold = false;
    try {
        // Create a client socket
        client = new net.Socket();
        // Connect to PrintHold.
        var port = 3250;
        client.connect(port, 'localhost', () => {
            console.log('Connected to server on localhost:' + port);
            bConnectedToPrintHold = true;
        }).on('error', (error) => {
            console.log("Cannot connect to PrintHold on local port " + port);
            console.log("Continuing without printing slips.");
            //process.exit(2);
        });

        url = kohaUrlStaffBase + '/cgi-bin/koha/circ/returns.pl';
        // Wait for debugging purposes
        // await new Promise(resolve => setTimeout(resolve, 1700));

        // Login to the "Check in" page used to trap holds.
        [browserMain, page] = await startBrowserAndLogin(url);
        // Login to the "Holds awaiting pickup for your library" page.
        var urlAwaitingPickup = kohaUrlStaffBase + '/cgi-bin/koha/circ/waitingreserves.pl';
        [browserAwaitingPickup, pageAwaitingPickup] = await startBrowserAndLogin(urlAwaitingPickup);

        while (true) {
            var bConfirmedHold = false;
            var bPrintSlip = false;
            // Get barcode from the user and send to the form.
            var barcode, title, callNumber, expirationDate, patronLastFirst;
            var currentDateTime, library;
            var quit = false;
            do {
                console.log('');
                barcode = await getUserInput('Enter barcode: ');
                barcode = barcode.trim();
                console.log(`Barcode: "${barcode}"`);
                if (barcode == 'quit' || barcode == 'exit' || barcode == 'q') {
                    quit = true;
                    break;
                }
            } while (barcode.length < 14);
            if (quit) {
                break;
            }

            await page.type('#barcode', barcode);

            await page.click('button[type="submit"].btn.btn-primary');

            // Wait for the dialog to become visible to load
            await page.waitForSelector('.modal-header', { visible: true });

            const h3Text = await page.evaluate(() => {
                const h3Elements = Array.from(document.querySelectorAll('h3'));
                for (let h3 of h3Elements) {
                    if (h3.textContent.includes('Hold found')) {
                        return h3.textContent;
                    }
                }
                return null;
            });

            if (h3Text != null) {
                console.log('h3 found: ' + h3Text);
                if (h3Text.includes('(item is already waiting)')) {
                    console.log('Item is already waiting; will choose Ignore button.');
                    await page.click('button[data-dismiss="modal"][aria-hidden="true"][type="submit"].btn.btn-default[accesskey="I"]');
                } else {
                    // Get the patron name; it's in last, first format. 
                    patronLastFirst = await page.evaluate(() => {
                        const h5Elements = [...document.querySelectorAll('h5')];
                        const targetH5 = h5Elements.find(h5 => h5.textContent.includes('Hold for:'));
                        if (!targetH5) return '';

                        const ulElement = targetH5.nextElementSibling;
                        if (!ulElement || ulElement.tagName !== 'UL') return '';

                        const liElement = ulElement.querySelector('li');
                        if (!liElement) return '';

                        const aElement = liElement.querySelector('a');
                        return aElement ? aElement.textContent.trim() : '';
                    });
                    // Strip the (barcode) from the patron name.
                    patronLastFirst = patronLastFirst.replace(/\(\d+\)$/, '').trim();
                    console.log('Patron name: ' + patronLastFirst);

                    // The h3 element looks like this:
                    // <h3>
                    // Hold found:
                    // <br>
                    // <a href="/cgi-bin/koha/catalogue/detail.pl?type=intra&amp;biblionumber=230">The early writings of Frederick Jackson Turner :</a>
                    title = await page.evaluate(() => {
                        const h3Elements = document.querySelectorAll('h3');
                        for (let h3 of h3Elements) {
                            if (h3.textContent.includes('Hold found:')) {
                                const aElement = h3.querySelector('a');
                                return aElement ? aElement.textContent : '';
                            }
                        }
                        return '';
                    });

                    console.log('Title: ' + title);
                    const now = new Date();
                    // Get each part of the date and time
                    const month = String(now.getMonth() + 1).padStart(2, '0'); // Months are 0-based, add 1 to get the correct month
                    const day = String(now.getDate()).padStart(2, '0');
                    const year = now.getFullYear();
                    const hours = String(now.getHours()).padStart(2, '0');
                    const minutes = String(now.getMinutes()).padStart(2, '0');

                    // Format the date and time in MM/DD/YYYY HH:mm format
                    currentDateTime = `${month}/${day}/${year} ${hours}:${minutes}`;

                    h4element = await page.$('h4');
                    if (h4element) {
                        const h4text = await page.evaluate(h4element => h4element.textContent, h4element);
                        console.log('Hold text: ' + h4text);
                        if (h4text.includes('Transfer to:')) {
                            console.log('Hold found that needs to be transferred.');
                            const buttonElement = await page.$('button[type="submit"].btn.btn-default.approve');
                            if (buttonElement) {
                                console.log('A button of type "submit" with classes "btn btn-default approve" exists.');
                                await page.click('button[type="submit"].btn.btn-default.approve');
                                console.log('Confirm hold button clicked.');
                                await page.waitForSelector('.modal-header', { visible: false });
                                bConfirmedHold = true;
                            } else {
                                console.log('No confirm button found.');
                            }
                        } else if (h4text.includes('Hold at')) {
                            library = h4text.replace('Hold at ', '');
                            console.log('Hold found that does not need to be transferred.');
                            bPrintSlip = true;
                            // The code below was from when we used the "Print slip" button;
                            // now we just click the "Confirm hold" button and print the slip from 
                            // a separate app.
                            // const buttonElement = await page.$('button[type="button"].btn.btn-default.print');
                            // if (buttonElement) {
                            //     console.log('A button of type "button" with classes "btn btn-default print" exists.');
                            //     await page.click('button[type="button"].btn.btn-default.print');
                            //     console.log('Print slip button clicked.');
                            //     bConfirmedHold = true;
                            //     //await page.waitForNavigation({ waitUntil: 'networkidle0' });

                            const buttonElement = await page.$('button[type="submit"].btn.btn-default.approve');
                            if (buttonElement) {
                                console.log('A button of type "submit" with classes "btn btn-default approve" exists.');
                                await page.click('button[type="submit"].btn.btn-default.approve');
                                console.log("Confirm hold button clicked even though it's local; we'll print separately.");
                                bConfirmedHold = true;
                            } else {
                                console.log('No Confirm hold button found (local hold).');
                            }
                        } else {
                            console.log('Unknown hold type: ' + h4text);
                        }
                    } else {
                        console.log('No h4 found.');
                    }
                }
            } else {
                console.log('No h3 element with text containing "Hold found" found.');
                const problemElement = await page.$('p.problem');
                if (problemElement) {
                    console.log('A paragraph with class "problem" exists.');
                    const problemText = await page.evaluate(problemElement => problemElement.textContent, problemElement);
                    console.log('Problem text: ' + problemText);
                } else {
                    console.log('No paragraph with class "problem" found.');
                }
            }
            if (bConfirmedHold && bPrintSlip) {
                // Find the call number and expiration date of the item.
                [found, callNumber, expirationDate, patronName] = await findOtherFields(barcode);
                console.log('Call number: ' + callNumber);
                console.log('Expiration date: ' + expirationDate);
                console.log('Patron name: ' + patronName);
                // Send the info necessary to print the slip to the server.
                // There are two copies of the patron name; the one from the page
                // of waiting holds seems to be more reliable.

                client.on('error', (error) => {
                    console.error('An error occurred:', error);
                    // Handle the error as needed, e.g., retry the operation, log the error, notify the user, etc.
                });

                if (bConnectedToPrintHold) {
                    client.write(JSON.stringify({
                        barcode: barcode,
                        title: title,
                        patron: patronName,
                        library: library,
                        callnumber: callNumber,
                        expdate: expirationDate,
                        currentdatetime: currentDateTime
                    }), (error) => {
                        // This callback function is for handling errors specifically 
                        // related to the write operation.
                        if (error) {
                            console.error('Failed to write to PrintHold:', error);
                            console.log("You'll have to print the hold slip manually.");
                        } else {
                            console.log('Data successfully written to PrintHold.');
                        }
                    });
                    client.write('\x17');
                } else {
                    console.log('Cannot print hold slip; not connected to PrintHold.');
                }
            }
        }
    } catch (error) {
        console.error("Caught: " + error.message);
        console.error("Stack: " + error.stack);
    }

    readline.question('Press Enter to close the browser', () => {
        browserMain.close();
        browserAwaitingPickup.close();
        readline.close();
        process.exit(0);
    })
}

// Given a barcode, find certain fields of the held item with that barcode.
// Returns an array of:
// - found (true if barcode found)
// - callNumber
// - expirationDate
// - patronName
async function findOtherFields(barcode) {
    var found = false, callNumber, expirationDate, patronName, itry=0;

    // Loop, refreshing the page until the item with the barcode is found.
    do {
        itry++;
        // Assuming that we are logged into the "Holds awaiting pickup for your library" page,
        // refresh the page to pick up any items that we've just marked as waiting.
        console.log("Reloading page");
        await pageAwaitingPickup.reload({ waitUntil: "domcontentloaded" });

        // Type the barcode into the search box. This sets a filter that immediately
        // kicks in.
        let bSearchBoxAvailable = false;
        try {
            await pageAwaitingPickup.waitForSelector('input[type="search"][aria-controls="holdst"]', 
                { visible: true, timeout: 750});
            bSearchBoxAvailable = true;
        } catch (error) {
            bSearchBoxAvailable = false;
        }
        if(!bSearchBoxAvailable) {
            console.error("Search box not available; will retry.");
            continue;
        }

        await pageAwaitingPickup.type('input[type="search"][aria-controls="holdst"]', barcode);

        // Find the table with class holds_table and loop through all the 
        // columns of the first row.
        console.log("Finding table");
        const table = await pageAwaitingPickup.$('table.holds_table');
        console.log("Finding rows");
        const rows = await table.$$('tr');
        console.log("Finding cells");
        const cells = await rows[0].$$('th');
        var callNumberCol, expirationDateCol, titleCol, patronCol;
        for (let icol = 0; icol < cells.length; icol++) {
            const cell = cells[icol];
            const text = await pageAwaitingPickup.evaluate(cell => cell.textContent, cell);
            if (text.includes('Call number')) {
                callNumberCol = icol;
            } else if (text.includes('Expiration date')) {
                expirationDateCol = icol;
            } else if (text.includes('Title')) {
                titleCol = icol;
            } else if (text.includes('Patron')) {
                patronCol = icol;
            }
        }

        console.log('Call number column: ' + callNumberCol);
        console.log('Expiration date column: ' + expirationDateCol);
        console.log('Title column: ' + titleCol);
        console.log('Patron column: ' + patronCol);
        if (null == callNumberCol || null == expirationDateCol || null == titleCol || null == patronCol) {
            console.error("Could not find one or more of the columns.");
            readline.question('Press Enter to close the browser', () => {
                browser.close();
                readline.close();
            });
            return;
        }

        // Loop through the rows, looking for the one for this barcode.
        for (let irow = 1; irow < rows.length; irow++) {
            console.log(`Processing row ${irow} of ${rows.length - 1}`);
            const cells = await rows[irow].$$('th, td'); // Select both header and data cells
            var cellBarcodeText;
            try {
                cellBarcodeText = await pageAwaitingPickup.evaluate(cell => cell.textContent, cells[titleCol]);
            } catch (error) {
                console.error("Error getting text from cell: " + error.message);
                console.error("Will refresh the page and try again.");
                break;
            }
            // The table cell for the title looks like this:
            // <td>
            // <a href="/cgi-bin/koha/catalogue/detail.pl?biblionumber=479" class="title">  
            //   <span class="biblio-title">They have a word for it :</span>  
            //   <span class="subtitle">a lighthearted lexicon of untranslatable words &amp; phrases /</span>    </a>
            // <br>Barcode: 43701001902378
            // </td>
            if (cellBarcodeText.includes(barcode)) {
                console.log('Found barcode ' + barcode + ' in row ' + irow);
                console.log('Title: ' + cellBarcodeText);
                callNumber = await pageAwaitingPickup.evaluate(cell => cell.textContent, cells[callNumberCol]);
                console.log('Call number: ' + callNumber);
                expirationDate = await pageAwaitingPickup.evaluate(cell => cell.textContent, cells[expirationDateCol]);
                console.log('Expiration date: ' + expirationDate);
                patronName = await pageAwaitingPickup.evaluate(cell => cell.textContent, cells[patronCol]);
                // Remove (barcode) from patron name, if present.
                if (patronName.includes('(')) {
                    patronName = patronName.substring(0, patronName.indexOf('(')).trim();
                }
                console.log('Patron name: ' + patronName);
                // Do a reality check on certain fields. 
                if (patronName.length > 5) {
                    found = true;
                }
                break;
            }
        }
    } while (!found && itry < 4);
    if (!found) {
        console.error('Barcode not found in the table.');
    }
    console.log("returning from findOtherFields");
    return [found, callNumber, expirationDate, patronName];
}

async function main() {
    await getSettings();
    run();
}

main();
