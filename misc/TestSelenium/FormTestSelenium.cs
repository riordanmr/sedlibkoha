using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestSelenium
{
    public partial class FormTestSelenium : Form
    {
        public IWebDriver driver1;
        public ChromeDriver driver2;
        public Settings settings;
        public PatronProc patronProc = new PatronProc();
        private readonly Random random = new Random();

        public FormTestSelenium() {
            InitializeComponent();

            this.Shown += OnFormShown;
        }

        private void OnFormShown(object sender, EventArgs e) {
            // Add your code here
            settings = Settings.Load();
            driver1 = CreateWebDriver();
        }

        IWebDriver CreateWebDriver() {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; // This hides the command prompt window

            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            return new ChromeDriver(service, options);
        }

        bool Login(string url) {
            bool bOK = false;
            driver1.Navigate().GoToUrl(url);
            // Initialize WebDriverWait with a timeout (e.g., 10 seconds)
            WebDriverWait wait1 = new WebDriverWait(driver1, TimeSpan.FromSeconds(10));

            // Wait until the input element with name 'userid' is visible
            IWebElement userIdInput = wait1.Until(ExpectedConditions.ElementIsVisible(By.Name("userid")));
            // Enter the username into the input element
            userIdInput.SendKeys(settings.KohaUsername);

            IWebElement passwordInput = driver1.FindElement(By.Name("password"));
            passwordInput.SendKeys(settings.KohaPassword);
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

        private void buttonLaunch_Click(object sender, EventArgs e) {
            {
                // Optional: Adjust settings or specify options for the driver if needed
                // For example, to run Chrome headlessly (without UI):
                // var options = new ChromeOptions();
                // options.AddArgument("--headless");
                // using (var driver = new ChromeDriver(options)) { ... }

                try {
                    string checkinUrl = settings.KohaStaffWebUrl + "/cgi-bin/koha/circ/returns.pl";
                    Login(checkinUrl);

                        // Add any additional actions here, such as logging in, navigating pages, etc.
                        // Example: driver.FindElement(By.Name("q")).SendKeys("Selenium");

                        // Optionally, close the browser
                        // driver.Quit();
                        //driver2.Navigate().GoToUrl("https://60bits.net");

                } catch (WebDriverException ex) {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void DoExit() {
            settings.Save();
            if(null != driver1) driver1.Quit();
            if(null != driver2) driver2.Quit();
            Environment.Exit(0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            DoExit();
        }

        private void buttonAddPatron_Click(object sender, EventArgs e) {
            Patron patron = new Patron();
            patron.firstname = this.textBoxFirstName.Text;
            patron.surname = this.textBoxLastName.Text;
            patron.email = this.textBoxEmail.Text;
            patron.Phone = this.textBoxPhone.Text;
            patron.Address = this.textBoxAddress1.Text;
            patron.address2 = this.textBoxAddress2.Text;
            patron.city = this.textBoxCity.Text;
            patron.State = this.comboBoxState.Text;
            patron.postal_code = this.textBoxZipcode.Text;
            patron.Country = "US";
            patron.userid = this.textBoxLibraryCardBarcode.Text;
            patron.cardnumber = this.textBoxLibraryCardBarcode.Text;
            patron.date_of_birth = this.textBoxDateOfBirth.Text;
            patron.Password = "password";
            patron.category_id = "AD";

            patronProc.AddPatron(patron);
        }

        public string GetRandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GetRandomDigits(int length) {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void buttonGenerateRandom_Click(object sender, EventArgs e) {
            string PIN = GetRandomDigits(4);
            this.textBoxFirstName.Text = $"Xerxes";
            this.textBoxLastName.Text = $"Smith{GetRandomString(3)}";
            this.textBoxDateOfBirth.Text = $"2000-07-21";
            this.textBoxEmail.Text = $"fred.smith{GetRandomString(5)}@gmail.com";
            this.textBoxPhone.Text = $"555-555-{GetRandomDigits(4)}";
            this.textBoxAddress1.Text = $"{PIN} Main St";
            this.textBoxAddress2.Text = $"Apt {GetRandomString(3)}";
            this.textBoxCity.Text = $"Springfield";
            this.comboBoxState.Text = $"IL";
            this.textBoxZipcode.Text = $"{GetRandomDigits(5)}";
            this.textBoxLibraryCardBarcode.Text = $"432{GetRandomDigits(11)}";
            this.textBoxPIN.Text = PIN;
            this.textBoxPIN2.Text = this.textBoxPIN.Text;
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            DoExit();
        }
    }
}
