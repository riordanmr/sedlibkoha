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
        public IWebDriver driver1;
        public WebDriverWait wait1;

        public KohaSession() {
            driver1 = CreateWebDriver();
            // Initialize WebDriverWait with a timeout.
            wait1 = new WebDriverWait(driver1, TimeSpan.FromSeconds(666));

        }

        void ShowMsg(string msg) {
            System.Diagnostics.Debug.WriteLine(msg);
            Program.FormMain.ShowMsg(msg);
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
            int yPos = 10;
            string optionsStr = $"window-position={xPos},{yPos}";
            options.AddArgument(optionsStr);
            //options.AddArgument("--headless");
            return new ChromeDriver(service, options);
        }

        public bool Login(string url) {
            bool bOK = false;
            driver1.Navigate().GoToUrl(url);

            // Wait until the input element with name 'userid' is visible
            IWebElement userIdInput = wait1.Until(ExpectedConditions.ElementIsVisible(By.Name("userid")));
            // Enter the username into the input element
            userIdInput.SendKeys(Program.FormMain.creds.KohaUsername);

            IWebElement passwordInput = driver1.FindElement(By.Name("password"));
            passwordInput.SendKeys(Program.FormMain.creds.KohaPassword);
            IWebElement submitButton = driver1.FindElement(By.Id("submit-button"));
            submitButton.Click();

            // Wait for the page to load completely by checking the document's ready state
            wait1.Until((driver) =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            // Check if the page contains the text "Invalid username or password"
            if (driver1.PageSource.Contains("Invalid username or password")) {
                MessageBox.Show("Invalid username or password. Please correct and try again.",
                    "Login failure", MessageBoxButtons.OK);
            } else {
                bOK = true; // Login successful
            }
            return bOK;
        }

        public bool AtUrl(string url) {
            return url == driver1.Url;
        }

        public void TrapHold(string barcode, out TrapHoldItemStatus statusOut) {
            string url = Program.FormMain.settings.KohaUrlStaff + "/cgi-bin/koha/circ/returns.pl";
            statusOut = TrapHoldItemStatus.None;
            TrapHoldItemStatus status = TrapHoldItemStatus.None;
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

                // Wait for the page to load completely by checking the document's ready state
                wait1.Until((driver) => ((IJavaScriptExecutor)driver).
                    ExecuteScript("return document.readyState").Equals("complete"));

                string pageSource = driver1.PageSource;
                ShowMsg($"Before loop, page source length: {pageSource.Length}");
                if (pageSource.Contains("Transfer to:")) {
                    ShowMsg("Dbg: Transfer to found");
                } else if (pageSource.Contains("Hold at")) {
                    ShowMsg("Dbg: Hold at found");
                } else {
                    ShowMsg("Dbg: No hold found");
                }

                IWebElement webElement;

                // Look for a hold that needs to be transferred to another branch.
                try {
                    ShowMsg("Looking for Transfer to:, one time");
                    webElement = driver1.FindElement(By.XPath(
                        "//h4[strong[contains(text(), 'Transfer to:')]]"));
                    ShowMsg("Found Transfer to:, one time");
                    status = TrapHoldItemStatus.HoldFoundTransfer;

                    ShowMsg("Looking for Ignore (I)");
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
                        IWebElement ignoreButton = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(
                            "button.btn.btn-default.deny")));

                        // Click the button
                        ignoreButton.Click();
                        ShowMsg("Clicked on Ignore for Transfer");
                    } catch (NoSuchElementException) {
                        ShowMsg("Didn't find Ignore (I)");
                    }
                } catch (NoSuchElementException) {
                    ShowMsg("Didn't find Transfer to: one time");
                }

                // Look for a local hold.
                if (status == TrapHoldItemStatus.None) {
                    try {
                        webElement = driver1.FindElement(By.XPath(
                            "//h4[strong[contains(text(), 'Hold at')]]"));
                        status = TrapHoldItemStatus.HoldFoundLocal;
                        ShowMsg("Found Hold at");

                        ShowMsg("Looking for Ignore (I)");
                        IWebElement ignoreButton = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(
                           "button.btn.btn-default.deny")));

                        ShowMsg("Local hold Ignore button found and is visible");

                        ShowMsg($"Found Ignore button; Displayed={ignoreButton.Displayed} Enabled={ignoreButton.Enabled}");
                        ShowMsg($"About to click on Ignore button for local hold: {ignoreButton}");
                        // Click the button
                        ignoreButton.Click();
                        ShowMsg("Clicked on Ignore for Hold at");

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


                //if (false) {
                //    // Wait we find one of several elements that indicate the status of the item.
                //    IWebElement element = wait1.Until(driver => {
                //        ShowMsg($"In loop, page source length: {driver.PageSource.Length}");
                //        try {
                //            webElement = driver.FindElement(By.XPath(
                //                "//h4[contains(text(), 'Hold at')]"));
                //            status = TrapHoldItemStatus.HoldFoundLocal;
                //            IWebElement ignoreButton = driver.FindElement(By.XPath(
                //                "//button[contains(text(), 'Ignore (I)')]"));
                //            // Click the button
                //            ignoreButton.Click();
                //            ShowMsg("Clicked on Ignore for Hold at");
                //            return webElement;
                //        } catch (NoSuchElementException) {
                //            ShowMsg("Didn't find Hold at");
                //        }
                //        try {
                //            webElement = driver.FindElement(By.XPath(
                //                "//h4[strong[contains(text(), 'Transfer to:')]]"));
                //            status = TrapHoldItemStatus.HoldFoundTransfer;
                //            IWebElement ignoreButton = driver.FindElement(By.XPath(
                //                "//button[contains(text(), 'Ignore (I)')]"));
                //            // Click the button
                //            ignoreButton.Click();
                //            ShowMsg("Clicked on Ignore for Transfer");
                //            return webElement;
                //        } catch (NoSuchElementException) {
                //            ShowMsg("Didn't find Transfer to:");
                //        }
                //        try {
                //            webElement = driver.FindElement(By.XPath(
                //                "//p[contains(@class, 'problem ret_badbarcode') and contains(text(), 'No item with barcode:')]"));
                //            status = TrapHoldItemStatus.NoSuchItem;
                //            return webElement;
                //        } catch (NoSuchElementException) {
                //            ShowMsg("Didn't find No item with barcode:");
                //        }
                //        try {
                //            //webElement = driver.FindElement(By.XPath(
                //            //    "//p[contains(@class, 'problem ret_notissued') and contains(text(), 'Not checked out.')]"));
                //            //status = TrapHoldItemStatus.NoHold;
                //            //return webElement;
                //        } catch (NoSuchElementException) {
                //            ShowMsg("Didn't find Not checked out.");
                //            return null;
                //        }
                //    });
                //}

            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
            statusOut = status;
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
