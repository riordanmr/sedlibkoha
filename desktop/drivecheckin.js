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

var kohaUrlStaffBase, kohaUsername, kohaPassword;


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

async function run() {
    //const browser = await puppeteer.launch();
    const browser = await puppeteer.launch({ headless: false });

    try {
        const page = await browser.newPage();

        url = kohaUrlStaffBase + '/cgi-bin/koha/circ/returns.pl'
        await page.goto(url);

        await page.type('#userid', kohaUsername);
        await page.type('#password', kohaPassword);
        await Promise.all([
            page.click('#submit-button'),
            page.waitForNavigation({ waitUntil: 'networkidle0' })
        ]);

        // Wait for debugging purposes
        // await new Promise(resolve => setTimeout(resolve, 1700));

        while (true) {
            // Get barcode from the user and send to the form.
            var barcode;
            var quit = false;
            do {
                barcode = await getUserInput('Enter barcode: ');
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

            // Wait for the page to load
            await page.waitForNavigation({ waitUntil: 'networkidle0' });

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
                    console.log('Item is already waiting; no action taken.');
                } else {
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
                                await page.waitForNavigation({ waitUntil: 'networkidle0' });
                            } else {
                                console.log('No confirm button found.');
                            }
                        } else if (h4text.includes('Hold at')) {
                            console.log('Hold found that does not need to be transferred.');
                            const buttonElement = await page.$('button[type="button"].btn.btn-default.print');
                            if (buttonElement) {
                                console.log('A button of type "button" with classes "btn btn-default print" exists.');
                                await page.click('button[type="button"].btn.btn-default.print');
                                console.log('Print slip button clicked.');
                                //await page.waitForNavigation({ waitUntil: 'networkidle0' });
                            } else {
                                console.log('No print button found.');
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
        }
    } catch (error) {
        console.error("Caught: " + error);
    }

    readline.question('Press Enter to close the browser', () => {
        browser.close();
        readline.close();
    })
}

async function main() {
    await getSettings();
    run();
}

main();
