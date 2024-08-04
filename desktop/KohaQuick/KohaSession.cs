using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;


namespace KohaQuick {
    public enum TrapHoldItemStatus {
        None,
        Error,
        NoSuchItem,
        NoHold,
        HoldFoundLocal,
        HoldFoundTransfer
    };

    public enum LoginStatus {
        None,
        Success,
        Failure,
        Unknown
    };

    public class CheckoutItem {
        //public string barcode { get; set; }
        public string due_date { get; set; }
        public string checkout_date { get; set; }
        public string call_number { get; set; }
        public string title { get; set; }

        public override string ToString() {
            return $"{{Title: {title}, Call number: {call_number}, Checked out: {checkout_date}, Due Date: {due_date}}}";
        }
    }

    public class CheckoutItemCol {
        public string patronFirstName { get; set; }
        public string patronLastName { get; set; }
        public List<CheckoutItem> items { get; set; } = new List<CheckoutItem>();

        public override string ToString() {
            var itemsInfo = string.Join(", ", items.Select(item => item.ToString()));
            return $"Patron: {patronFirstName} {patronLastName}; {items.Count} Items: [{itemsInfo}]";
        }

        public void AddCheckout(string titleParm, string callNumberParm, string checkedOutOnParm, 
            string due_dateParm) {
            items.Add(new CheckoutItem {
                title = titleParm,
                call_number = callNumberParm,
                checkout_date = checkedOutOnParm,
                due_date = due_dateParm,
            });
        }


        public void RemoveCheckoutsNotToday() {
            int nItemsRemoved = 0;
            string strToday = DateTime.Now.Date.ToString("MM/dd/yyyy");
            for (int i = this.items.Count - 1; i >= 0; i--) {
                if (this.items[i].checkout_date != strToday) {
                    this.items.RemoveAt(i);
                    nItemsRemoved++;
                }
            }
            Program.FormMain.ShowMsg($"RemoveCheckoutsNotToday: Removed {nItemsRemoved} items");
        }
    }

    // Represents a browser session to Koha.
    public class KohaSession {
        const int MAX_PAGE_WAIT_SECS = 7;
        public IWebDriver driver;
        public WebDriverWait wait1;
        public int sessionNum;

        public KohaSession(int sessNum) {
            sessionNum = sessNum;
            driver = CreateWebDriver();
            // Initialize WebDriverWait with a timeout.
            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(MAX_PAGE_WAIT_SECS));
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
            int desiredChromeWidth = Program.FormMain.settings.BrowserWidth;
            int desiredChromeHeight = Program.FormMain.settings.BrowserHeight;
            options.AddArgument($"window-size={desiredChromeWidth},{desiredChromeHeight}");
            // Set the window position (x, y)
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int xPos = screenWidth - desiredChromeWidth - 56;
            if(Program.FormMain.settings.BrowserX >= 0) {
                xPos = Program.FormMain.settings.BrowserX;
            }
            int yPos;
            if (sessionNum == 1) {
                yPos = 0;
            } else if(sessionNum == 2) {
                yPos = (int)(desiredChromeHeight * 0.8);
            } else {
                yPos = (int)(desiredChromeHeight * 0.8) + (30*(sessionNum-1));
            }
            
            string optionsStr = $"window-position={xPos},{yPos}";
            options.AddArgument(optionsStr);

            if (Program.FormMain.settings.BrowserWindowState == Settings.BROWSER_WINDOW_STATE_HIDDEN) {
                ShowMsg($"Setting browser position to hidden");
                options.AddArgument("--headless");
            }
            IWebDriver driver = new ChromeDriver(service, options);
            if (Program.FormMain.settings.BrowserWindowState == Settings.BROWSER_WINDOW_STATE_MINIMIZED) {
                driver.Manage().Window.Minimize();
                ShowMsg($"Setting browser position to minimized");
            }
            return driver;
        }

        void WaitForPageToLoad() {
            // Wait for the page to load completely by checking the document's ready state
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MAX_PAGE_WAIT_SECS));
            wait.Until(driver => ((IJavaScriptExecutor)driver).
               ExecuteScript("return document.readyState").Equals("complete"));
        }

        IWebElement WaitForElement(By by) {
            try {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MAX_PAGE_WAIT_SECS));
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            } catch (WebDriverTimeoutException) {
                return null;
            }
        }


        string GetTitle() {
            // Find all h3 elements
            IReadOnlyCollection<IWebElement> h3Elements = driver.FindElements(By.TagName("h3"));

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

        public bool LoginStaff(string url, string username, string password, out string errmsg) {
            bool bOK = false;
            errmsg = string.Empty;
            try {
                driver.Navigate().GoToUrl(url);
                WaitForPageToLoad();

                IWebElement userIdInput = wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("userid")));
                // Enter the username into the input element
                userIdInput.SendKeys(username);

                IWebElement passwordInput = driver.FindElement(By.Id("password"));
                passwordInput.SendKeys(password);

                IWebElement submitButton = driver.FindElement(By.Id("submit-button"));
                submitButton.Click();

                WaitForPageToLoad();

                // Check if the page contains the text "Invalid username or password"
                if (driver.PageSource.Contains("Invalid username or password")) {
                    //MessageBox.Show("Invalid username or password. Please correct and try again.",
                    //    "Login failure", MessageBoxButtons.OK);
                    errmsg = "Invalid username or password";
                } else if(driver.PageSource.Contains("You do not have permission")) {
                    errmsg = "You do not have permission to access this page";
                } else {
                    bOK = true; // Login successful
                }
            } catch (Exception ex) {
                ShowMsg(ex.Message);
                errmsg = ex.Message;
                //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowMsg($"Login returning {bOK}. {errmsg}");
            return bOK;
        }

        // Login a patron. The patron login page is different from the staff login page.
        public LoginStatus LoginPatron(string url, string username, string password, out string errmsg) {
            LoginStatus loginStatus = LoginStatus.None;
            errmsg = string.Empty;
            try {
                LogoutPatron();

                driver.Navigate().GoToUrl(url);
                WaitForPageToLoad();

                // Bizarrely, the patron login page has two similar login forms, one
                // of which is hidden.  
                IWebElement userIdInput = wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("userid")));
                // Enter the username into the input element
                userIdInput.SendKeys(username);

                IWebElement passwordInput = driver.FindElement(By.Id("password"));
                passwordInput.SendKeys(password);

                // Find the correct Log in button. This was difficult to figure out!
                IWebElement submitButton = driver.FindElement(By.CssSelector(
                    ".local-login:nth-child(2) .btn"));
                submitButton.Click();

                WaitForPageToLoad();
                Thread.Sleep(1000);

                ShowMsg($"After click on Log in : {driver.PageSource}");

                // Check if the page contains the text "Invalid username or password"
                if (driver.PageSource.Contains("Invalid username or password") ||
                    driver.PageSource.Contains("incorrect username or password")) {
                    //MessageBox.Show("Invalid username or password. Please correct and try again.",
                    //    "Login failure", MessageBoxButtons.OK);
                    errmsg = "Incorrect user barcode or PIN";
                    loginStatus = LoginStatus.Failure;
                } else if (driver.PageSource.Contains("You do not have permission")) {
                    errmsg = "You do not have permission to access this page";
                    loginStatus = LoginStatus.Failure;
                } else if (driver.PageSource.Contains("Your summary") ||
                    driver.PageSource.Contains("Welcome, ")) {
                    // Check for text confirming that we logged in OK.
                    //ShowMsg($"Looking for successful login");
                    //IWebElement summaryHeader = wait1.Until(ExpectedConditions.ElementIsVisible(
                    //    By.XPath("//h1[text()='Your summary']")));
                    loginStatus = LoginStatus.Success;
                } else {
                    errmsg = "I don't recognize this page. See debug log.";
                    ShowMsg($"LoginPatron doesn't recognize this page: {driver.PageSource}");
                    loginStatus = LoginStatus.Unknown;
                }
            } catch (Exception ex) {
                ShowMsg(ex.Message);
                errmsg = ex.Message;
                loginStatus = LoginStatus.Unknown;
                //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowMsg($"Login returning {loginStatus}. {errmsg}");
            return loginStatus;
        }

        public void LogoutStaff() {
            string url = Program.FormMain.settings.KohaUrlStaff + "/cgi-bin/koha/mainpage.pl?logout.x=1";
            driver.Navigate().GoToUrl(url);
            try {
                WaitForPageToLoad();
                wait1.Until((driver) => ((IJavaScriptExecutor)driver).
                    ExecuteScript("return document.readyState").Equals("complete"));
            } catch (Exception ex) {
                ShowMsg($"Logout staff: {ex.Message}");
            }
        }

        public void LogoutPatron() {
            string url = Program.FormMain.settings.KohaUrlPatron + "/cgi-bin/koha/opac-main.pl?logout.x=1";
            driver.Navigate().GoToUrl(url);
            try {
                WaitForPageToLoad();
                wait1.Until((driver) => ((IJavaScriptExecutor)driver).
                    ExecuteScript("return document.readyState").Equals("complete"));
            } catch (Exception ex) {
                ShowMsg($"Logout patron: {ex.Message}");
            }
        }

        public bool AtUrl(string url) {
            return url == driver.Url;
        }

        public bool EnsureAtUrl(string url) {
            bool bOK = false;
            if (AtUrl(url)) {
                bOK = true;
            } else {
                driver.Navigate().GoToUrl(url);
                try {
                    WaitForPageToLoad();
                    bOK = true;
                } catch (Exception ex) {
                    ShowMsg($"Logout patron: {ex.Message}");
                }
            }
            return bOK;
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
                    driver.Navigate().GoToUrl(url);
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
                    webElement = driver.FindElement(By.XPath(
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
                        webElement = driver.FindElement(By.XPath(
                            "//h4[strong[contains(text(), 'Hold at')]]"));
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
                        webElement = driver.FindElement(By.XPath(
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

                    // Find the title of the item.
                    // Find the h3 element containing the text "Check in message"
                    var h3Element = driver.FindElement(By.XPath("//h3[contains(text(), 'Check in message')]"));

                    if (h3Element != null) {
                        // Find the first p element following the h3 element
                        var pElement = h3Element.FindElement(By.XPath("following-sibling::p"));

                        if (pElement != null) {
                            // Find the first a element under the p element
                            var aElement = pElement.FindElement(By.XPath(".//a"));

                            if (aElement != null) {
                                // Get the text of the a element
                                string linkText = aElement.Text;
                                ShowMsg("Item apparently not on hold. Link Text: " + linkText);
                                message = linkText;
                            } else {
                                ShowMsg("No a element found under the p element.");
                            }
                        } else {
                            ShowMsg("No p element found following the h3 element.");
                        }
                    } else {
                        ShowMsg("No h3 element containing 'Check in message' found.");
                    }
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
                driver.Navigate().GoToUrl(url);
                WaitForPageToLoad();
            }

            for (int itry = 0; !bOK && (itry < 3); itry++) {
                try {
                    ShowMsg("Refreshing waiting reserves page...");

                    // Refresh the page
                    driver.Navigate().Refresh();
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

        public bool GetItemsCheckedOutForPatron(string url, string barcode, 
            ref CheckoutItemCol checkoutItemCol, out string errmsg) {
            bool bOK = false;
            errmsg = "";

            try {
                EnsureAtUrl(url);

                driver.FindElement(By.Id("findborrower")).SendKeys(barcode);
                driver.FindElement(By.CssSelector("#patronsearch > button > .fa")).Click();

                bool bPatronFound = false;
                bool isConditionMet = wait1.Until(drv =>
                {
                    try {
                        // Check for the div with id 'memberresultst_info' containing the text 'No entries to show'
                        var divElement = drv.FindElement(By.Id("memberresultst_info"));
                        if (divElement.Text.Contains("No entries to show")) {
                            ShowMsg($"Found \"No entries to show\", indicating that the patron with card number {barcode} was not found");
                            return true;
                        }
                    } catch (NoSuchElementException) {
                        ShowMsg("GetItemsCheckedOutForPatron: \"No entries to show\" not found");
                    }

                    string lookfor = "(" + barcode + ")";
                    try {
                        // Check for the h1 containing the text '(barcode)'
                        var h1Element = driver.FindElements(By.TagName("h1"))
                          .FirstOrDefault(e => e.Text.Contains(lookfor));
                        // If we get here, we didn't get an exception. 
                        ShowMsg($"Found patron text \"{lookfor}\"");
                        bPatronFound = true;
                        return true;
                    } catch (NoSuchElementException) {
                        ShowMsg($"GetItemsCheckedOutForPatron: Could not find h1 with {lookfor}");
                    }

                    return false;
                });

                if (!bPatronFound) {
                    errmsg = $"Could not find patron with card number {barcode}";
                    return false;
                }

                // Locate the span element with class 'checkout_count'
                IWebElement spanElement = driver.FindElement(By.ClassName("checkout_count"));
                // Fetch the text of the span element
                string spanText = spanElement.Text;
                ShowMsg($"Checkout count: {spanText}");
                if(spanText == "0") {
                    errmsg = $"No items checked out patron with card number {barcode}";
                    return false;
                }

                // Do we need to explicitly load the checkouts?
                IWebElement checkbox = driver.FindElement(By.Id("issues-table-load-immediately"));
                if (!checkbox.Selected) {
                    // Yes, they are not automatically loaded, so we need to load the checkouts.
                    driver.FindElement(By.Id("issues-table-load-now-button")).Click();
                    WaitForPageToLoad();
                }
                {
                    var element = driver.FindElement(By.CssSelector(".buttons-colvis"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).Perform();
                }
                {
                    var element = driver.FindElement(By.TagName("body"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element, 0, 0).Perform();
                }
                {
                    var element = driver.FindElement(By.CssSelector(".export_controls"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).Perform();
                }
                {
                    var element = driver.FindElement(By.TagName("body"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element, 0, 0).Perform();
                }
                driver.FindElement(By.CssSelector(".export_controls .dt-button-text")).Click();
                driver.FindElement(By.CssSelector(".buttons-csv > span")).Click();

                string foundFilePath;
                if (Util.FindRecentDownloadedFile("Checking out*.csv", 10000, out foundFilePath)) {
                    ShowMsg($"Found {foundFilePath}");
                    bOK = Util.ParseCheckedOutCSV(foundFilePath, ref checkoutItemCol, out errmsg);
                }
            } catch(Exception ex) {
                ShowMsg($"GetItemsCheckedOutForPatron: {ex.Message}");
                errmsg = ex.Message;
            }
            return bOK;
        }


        public void Close() {
            try {
                driver.Close();
                driver.Quit();
            } catch (Exception) {
                // Ignore
            }
        }
    }
}
