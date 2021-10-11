using System;
using System.Threading;
using System.Text;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using aut4CsharpNUnit;
using aut4CsharpNUnit.PageObject;

namespace TestCase_Suite
{
    [TestFixture]
    public class LoginTest
    {
        private RemoteWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        // private IJavaScriptExecutor js;
        
        [SetUp]
        public void SetupTest()
        {
            //driver = new ChromeDriver();
            driver = BasicConfiguration.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);
            //driver = BasicConfiguration.GetBrowserLocal(driver, "default");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);

            baseURL = "https://luizoscar.nmbrs.nl/applications/Common/Login.aspx?view=2";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser!
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void ValidatingFirstScreen()
        {
            // website access
            driver.Navigate().GoToUrl(baseURL);
           
            LoginPage login = new LoginPage(driver);
            login.ValidatingElementsOnReturnScreen();
            login.ClickOnLogin();
            login.ValidatingElementsOnLoginScreen();
            login.ExecuteLogin();
            Thread.Sleep(5000);

            // JavaScript executor
            //BasicConfiguration.ExecuteJavaScript(driver, "document.querySelector('xxxxxxx').click()");
           

        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
