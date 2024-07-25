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
            wait1 = new WebDriverWait(driver1, TimeSpan.FromSeconds(7));

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

        public void TrapHold(string barcode, out TrapHoldItemStatus statusOut, out string message) {
            statusOut = TrapHoldItemStatus.None;
            message = string.Empty;
            string url = Program.FormMain.settings.KohaUrlStaff + "/cgi-bin/koha/circ/returns.pl";
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

                IWebElement webElement;

                // Now that the page is displaying the status of the item, figure out what to do.

                // Look for a hold that needs to be transferred to another branch.
                try {
                    ShowMsg("Looking for Transfer to:, one time");
                    webElement = driver1.FindElement(By.XPath(
                        "//h4[strong[contains(text(), 'Transfer to:')]]"));
                    ShowMsg("Found Transfer to:, one time");
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
                        ShowMsg("Clicked on Ignore for Transfer");
                    } catch (NoSuchElementException) {
                        ShowMsg("Didn't find Ignore button");
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

                        // At this point, a human would click the "Print slip and confirm (P)"
                        // button. But we don't, because we don't want to use the cumbersome
                        // browser print dialog to print the slip. Plus, we can print a 
                        // more attractive slip ourselves anyway.
                        // So we just click the Confirm button.
                        ShowMsg("Looking for Confirm hold button");
                        IWebElement confirmButton = wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(
                           "button.btn.btn-default.approve")));

                        ShowMsg("Local hold Ignore button found and is visible");

                        ShowMsg($"Found Ignore button; Displayed={confirmButton.Displayed} Enabled={confirmButton.Enabled}");
                        ShowMsg($"About to click on Ignore button for local hold: {confirmButton}");
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

        public void Close() {
            try {
                driver1.Close();
            } catch (Exception) {
                // Ignore
            }
        }
    }
}
