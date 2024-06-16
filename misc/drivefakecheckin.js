// Script to use Puppeteer to automate a browser to input 
// a barcode into a form and submit it.
// This script accesses a test webpage that mocks up the 
// Koha ILS barcode input screen.
// Eventually, the script will be modified to work with the
// Koha ILS.
// Mark Riordan  2024-06-15
const puppeteer = require('puppeteer');
const readline = require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
});

function getUserInput(query) {
    return new Promise(resolve => readline.question(query, resolve));
}

async function run() {
    //const browser = await puppeteer.launch();
    const browser = await puppeteer.launch({ headless: false });

    try {
        const page = await browser.newPage();
        console.log('When entering (fake) barcodes, type "quit" to exit the program.');
        console.log('Barcodes starting with 1 will show as local holds.');
        console.log('Barcodes starting with 2 will show as holds for Village of Oak Creek.');
        console.log('Barcodes starting with 3 will show as holds for other libraries.');

        // Replace with your URL
        url = 'file:///Users/mrr/Documents/GitHub/sedlibkoha/misc/fakecheckin.html'
        await page.goto(url);

        while (true) {
            // Get barcode from the user and send to the form.
            const barcode = await getUserInput('Enter barcode: ');
            console.log(`Barcode: "${barcode}"`);
            if (barcode == 'quit' || barcode == 'exit' || barcode == 'q') {
                break;
            }
            await page.type('#barcode', barcode);

            await page.click('#btnSubmitBarcode');

            // Wait for the page to load
            await new Promise(resolve => setTimeout(resolve, 700));

            // Click the 'Ignore' button
            await page.click('#btnIgnore');

            await new Promise(resolve => setTimeout(resolve, 100));
            //console.log('Ignore has been pressed. Press Enter to continue');

            const elementText = await page.$eval('#messages', element => element.textContent);

            console.log("Messages: " + elementText);
        }
    } catch (error) {
        console.error("Caught: " + error);
    }

    readline.question('Press Enter to close the browser', () => {
        browser.close();
        readline.close();
    })
}

run();
