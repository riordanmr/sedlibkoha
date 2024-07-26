using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KohaQuick.Properties;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using System.Linq.Expressions;
using System.Data;

namespace KohaQuick {
    public enum TrapHoldItemStatus {
        None,
        Error,
        NoSuchItem,
        NoHold,
        HoldFoundLocal,
        HoldFoundTransfer
    };

    // Represents a browser session to Koha.
    public class KohaSession {
        const int MAX_PAGE_WAIT_SECS = 7;
        public IWebDriver driver1;
        public WebDriverWait wait1;
        public int sessionNum;

        public KohaSession(int sessNum) {
            sessionNum = sessNum;
            driver1 = CreateWebDriver();
            // Initialize WebDriverWait with a timeout.
            wait1 = new WebDriverWait(driver1, TimeSpan.FromSeconds(MAX_PAGE_WAIT_SECS));

        }

        void ShowMsg(string msg) {
            System.Diagnostics.Debug.WriteLine(msg);
            Program.FormMain.ShowMsg(msg);
        }

        static string RemoveTextAfterFirst(string input, char delim) {
            int index = input.IndexOf(delim);
            if (index >= 0) {
                return input.Substring(0, index);
            }
            return input;
        }

        IWebDriver CreateWebDriver() {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; // This hides the command prompt window

            ChromeOptions options = new ChromeOptions();
            // Set the window size (width, height)
            int desiredChromeWidth = 600;
            int desiredChromeHeight = 600;
            options.AddArgument($"window-size={desiredChromeWidth},{desiredChromeHeight}");
            // Set the window position (x, y)
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int xPos = screenWidth - desiredChromeWidth - 56;
            int yPos = 500 * (sessionNum - 1);
            string optionsStr = $"window-position={xPos},{yPos}";
            options.AddArgument(optionsStr);
            //options.AddArgument("--headless");
            return new ChromeDriver(service, options);
        }

        void WaitForPageToLoad() {
            // Wait for the page to load completely by checking the document's ready state
            WebDriverWait wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(MAX_PAGE_WAIT_SECS));
            wait.Until(driver => ((IJavaScriptExecutor)driver).
               ExecuteScript("return document.readyState").Equals("complete"));
        }

        IWebElement WaitForElement(By by) {
            try {
                WebDriverWait wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(MAX_PAGE_WAIT_SECS));
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            } catch (WebDriverTimeoutException) {
                return null;
            }
        }


        string GetTitle() {
            // Find all h3 elements
            IReadOnlyCollection<IWebElement> h3Elements = driver1.FindElements(By.TagName("h3"));

            foreach (IWebElement h3 in h3Elements) {
                // Check if the h3 element's text includes "Hold found".
                if (h3.Text.Contains("Hold found:") || h3.Text.Contains("Hold found (item is already waiting):")) {
                    // Find the a element within the h3 element
                    IWebElement aElement = h3.FindElement(By.TagName("a"));
                    if (aElement != null) {
                        string title = aElement.Text;
                        return RemoveTextAfterFirst(title, '/');
                    } else {
                        return string.Empty;
                    }
                }
            }

            return string.Empty;
        }

        public bool Login(string url, string username, string password) {
            bool bOK = false;
            try {
                driver1.Navigate().GoToUrl(url);

                // Wait until the input element with name 'userid' is visible
                IWebElement userIdInput = wait1.Until(ExpectedConditions.ElementIsVisible(By.Name("userid")));
                // Enter the username into the input element
                userIdInput.SendKeys(username);

                IWebElement passwordInput = driver1.FindElement(By.Name("password"));
                passwordInput.SendKeys(password);
                IWebElement submitButton = driver1.FindElement(By.Id("submit-button"));
                submitButton.Click();

                WaitForPageToLoad();

                // Check if the page contains the text "Invalid username or password"
                if (driver1.PageSource.Contains("Invalid username or password")) {
                    MessageBox.Show("Invalid username or password. Please correct and try again.",
                        "Login failure", MessageBoxButtons.OK);
                } else {
                    bOK = true; // Login successful
                }
            } catch (Exception ex) {
                ShowMsg(ex.Message);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bOK;
        }

        public void Logout() {
            string url = Program.FormMain.settings.KohaUrlStaff + "/cgi-bin/koha/mainpage.pl?logout.x=1";
            driver1.Navigate().GoToUrl(url);
        }

        public bool AtUrl(string url) {
            return url == driver1.Url;
        }

        public void TrapHold(string barcode, ref HoldSlip holdSlip,
            out TrapHoldItemStatus statusOut, out string message) {
            statusOut = TrapHoldItemStatus.None;
            message = string.Empty;
            string url = Program.FormMain.settings.KohaUrlStaff + "/cgi-bin/koha/circ/returns.pl";
            TrapHoldItemStatus status = TrapHoldItemStatus.None;
            holdSlip.Currentdatetime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            try {
                if (!AtUrl(url)) {
                    driver1.Navigate().GoToUrl(url);
                    // Wait for the page to load completely by checking the document's ready state
                    wait1.Until((driver) => ((IJavaScriptExecutor)driver).
                        ExecuteScript("return document.readyState").Equals("complete"));
                }

                // Wait until the input element with id 'barcode' is visible
                IWebElement barcodeInput = wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("barcode")));

                barcodeInput.SendKeys(barcode);

                // Wait until the button element with text 'Check in' is visible
                IWebElement checkInButton = wait1.Until(ExpectedConditions.ElementIsVisible
                    (By.XPath("//button[contains(text(), 'Check in')]")));

                // Click the button
                checkInButton.Click();

                ShowMsg("Clicked on \"Check in\"");

                WaitForPageToLoad();

                IWebElement webElement;

                // Now that the page is displaying the status of the item, figure out what to do.

                // Look for a hold that needs to be transferred to another branch.
                try {
                    ShowMsg("Looking for Transfer to:, one time");
                    webElement = driver1.FindElement(By.XPath(
                        "//h4[strong[contains(text(), 'Transfer to:')]]"));
                    // If we get here, the element exists, but it might not be visible yet.
                    // We don't do the wait Until first, because the element might not exist
                    // at all on the page, and we'd wait until we timeout.
                    webElement = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                        "//h4[strong[contains(text(), 'Transfer to:')]]")));
                    ShowMsg("Found Transfer to:, one time");
                    string library = webElement.Text;
                    ShowMsg($"Found a transfer; Text={webElement.Text} Size={webElement.Size} Displayed={webElement.Displayed}");
                    library = library.Replace("Transfer to: ", "");
                    holdSlip.Library = library;
                    holdSlip.Title = GetTitle();
                    status = TrapHoldItemStatus.HoldFoundTransfer;

                    ShowMsg("Looking for Confirm hold and transfer button");
                    try {
                        // None of these worked. I don't understand why the XPath selector
                        // for the text on the button doesn't work.
                        //IWebElement ignoreButton = driver1.FindElement(By.XPath(
                        //    "//button[contains(text(), 'Ignore (I)')]"));
                        //IWebElement ignoreButton = driver1.FindElement(By.CssSelector(
                        //    "button.btn.btn-default.deny"));
                        //IWebElement ignoreButton = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                        //    "//button[contains(text(), 'Ignore (I)')]")));
                        //ShowMsg("Transfer Ignore button found and is visible");
                        IWebElement confirmButton = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(
                            "button.btn.btn-default.approve")));

                        // Click the button
                        confirmButton.Click();
                        ShowMsg("Clicked on Confirm for Transfer");
                    } catch (NoSuchElementException) {
                        ShowMsg("Didn't find Confirm button");
                    }
                } catch (NoSuchElementException) {
                    ShowMsg("Didn't find Transfer to: one time");
                }

                // Look for a local hold.
                if (status == TrapHoldItemStatus.None) {
                    try {
                        // Look for an element like:  <h4><strong>Hold at</strong> Franklin</h4>
                        // This didn't work; apparently the element existed but wasn't yet visible.
                        //webElement = driver1.FindElement(By.XPath(
                        //    "//h4[strong[contains(text(), 'Hold at')]]"));
                        webElement = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                            "//h4[strong[contains(text(), 'Hold at')]]")));
                        status = TrapHoldItemStatus.HoldFoundLocal;
                        string library = webElement.Text;
                        ShowMsg($"Hold text is: {library}");
                        library = library.Replace("Hold at ", "");
                        ShowMsg($"Found Hold at: {library}");
                        holdSlip.Library = library;
                        holdSlip.Title = GetTitle();

                        // At this point, a human would click the "Print slip and confirm (P)"
                        // button. But we don't, because we don't want to use the cumbersome
                        // browser print dialog to print the slip. Plus, we can print a 
                        // more attractive slip ourselves anyway.
                        // So we just click the Confirm button.
                        ShowMsg("Looking for Confirm hold button");
                        IWebElement confirmButton = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(
                           "button.btn.btn-default.approve")));

                        // Click the button
                        confirmButton.Click();
                        ShowMsg("Clicked on Confirm hold (Y) for Hold at");

                    } catch (NoSuchElementException) {
                        ShowMsg("Didn't find Hold at");
                    }
                }

                // Look for a message indicating no such item exists.
                if (status == TrapHoldItemStatus.None) {
                    try {
                        webElement = driver1.FindElement(By.XPath(
                            "//p[contains(@class, 'problem ret_badbarcode') and contains(text(), 'No item with barcode:')]"));
                        status = TrapHoldItemStatus.NoSuchItem;
                    } catch (NoSuchElementException) {
                        ShowMsg("Didn't find No item with barcode");
                    }
                }

                if (status == TrapHoldItemStatus.None) {
                    // Apparently if we get here, there was no hold on the item.
                    // Unfortunately, the web page doesn't have any direct indication of this.
                    status = TrapHoldItemStatus.NoHold;
                }

            } catch (Exception ex) {
                ShowMsg(ex.Message);
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            statusOut = status;
        }

        public bool GetInfoOnTrappedItem(string barcode, ref HoldSlip holdSlip) {
            bool bOK = false;
            string url = Program.FormMain.settings.KohaUrlStaff + "/cgi-bin/koha/circ/waitingreserves.pl";
            if (!AtUrl(url)) {
                driver1.Navigate().GoToUrl(url);
                WaitForPageToLoad();
            }

            for (int itry = 0; !bOK && (itry < 3); itry++) {
                try {
                    ShowMsg("Refreshing waiting reserves page...");

                    // Refresh the page
                    driver1.Navigate().Refresh();
                    WaitForPageToLoad();

                    IWebElement inputBox = WaitForElement(By.CssSelector(
                        "input[type='search'][aria-controls='holdst']"));
                    if (null == inputBox) {
                        ShowMsg("GetInfoOnTrappedItem: Couldn't find search box");
                        continue;
                    }

                    inputBox.SendKeys(barcode);

                    // Wait for the table to be updated with the search results
                    IWebElement table = WaitForElement(By.CssSelector("table.holds_table"));
                    if (null == table) {
                        ShowMsg("GetInfoOnTrappedItem: Couldn't find holds_table");
                        continue;
                    }

                    IReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));
                    if (rows.Count < 2) {
                        ShowMsg("GetInfoOnTrappedItem: No rows in table");
                        continue;
                    }

                    // Examine the header row to determine which column has which information.
                    IWebElement firstRow = rows.ElementAt(0);
                    IReadOnlyCollection<IWebElement> cells = firstRow.FindElements(By.CssSelector("th, td"));

                    int colCallNumber = -1, colExpirationDate = -1, colTitle = -1, colPatron = -1;
                    for (int i = 0; i < cells.Count; i++) {
                        string cellText = cells.ElementAt(i).Text;
                        if (cellText.Contains("Call number")) {
                            colCallNumber = i;
                        } else if (cellText.Contains("Expiration date")) {
                            colExpirationDate = i;
                        } else if (cellText.Contains("Title")) {
                            colTitle = i;
                        } else if (cellText.Contains("Patron")) {
                            colPatron = i;
                        }
                    }

                    if (colCallNumber == -1 || colExpirationDate == -1 || colTitle == -1 || colPatron == -1) {
                        ShowMsg("GetInfoOnTrappedItem: Couldn't find all column names");
                        continue;
                    }
                    ShowMsg($"Columns: Call number={colCallNumber}, Expdate={colExpirationDate}, Title={colTitle}, Patron={colPatron}");

                    // Now that we know which columns have which information, we can
                    // extract the information for the item we're interested in.
                    for (int irow = 1; irow < rows.Count; irow++) {
                        IWebElement row = rows.ElementAt(irow);
                        cells = row.FindElements(By.CssSelector("th, td"));
                        if (cells.Count < 4) {
                            ShowMsg("GetInfoOnTrappedItem: Not enough cells in row");
                            continue;
                        }

                        string callNumber = cells.ElementAt(colCallNumber).Text;
                        string expirationDate = cells.ElementAt(colExpirationDate).Text;
                        string title = cells.ElementAt(colTitle).Text;
                        string patron = cells.ElementAt(colPatron).Text;

                        patron = RemoveTextAfterFirst(patron, '(');

                        ShowMsg($"Examining row {irow}: {title}, {callNumber}, {expirationDate}, {patron}");

                        if (title.Contains(barcode)) {
                            ShowMsg($"GetInfoOnTrappedItem: Found the item we're looking for in row {irow}");

                            ShowMsg($"Call number: {callNumber}");
                            ShowMsg($"Expiration date: {expirationDate}");
                            ShowMsg($"Title: {title}");
                            ShowMsg($"Patron: {patron}");

                            holdSlip.Expdate = expirationDate;
                            holdSlip.Callnumber = callNumber;
                            holdSlip.Patron = patron;
                            //holdSlip.Title = title;

                            bOK = true;                            
                            break;
                        } else {
                            ShowMsg($"GetInfoOnTrappedItem: Row {irow} is not the item we're looking for");
                        }
                    }
                } catch (Exception ex) {
                    ShowMsg("GetInfoOnTrappedItem: " + ex.Message);
                }
            };

            return bOK;
        }


        public void Close() {
            try {
                driver1.Close();
            } catch (Exception) {
                // Ignore
            }
        }
    }
}
