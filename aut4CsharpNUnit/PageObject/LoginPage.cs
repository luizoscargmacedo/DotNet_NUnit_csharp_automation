using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace aut4CsharpNUnit.PageObject
{
    public class LoginPage
    {

        private RemoteWebDriver _driver;

        public LoginPage(RemoteWebDriver driver) => _driver = driver;

        IWebElement btnReturnLogin => _driver.FindElementById("returnLogin");
        IWebElement txtEmailField => _driver.FindElementById("txtEmail");
        IWebElement txtPasswordField => _driver.FindElementById("txtPassword");
        IWebElement btnLogin => _driver.FindElementById("btnLogin");

        public void ValidatingElementsOnReturnScreen()
        {
            Assert.IsTrue(btnReturnLogin.Enabled);
        }

        public void ClickOnLogin()
        {
            btnReturnLogin.Click();
        }

        public void ValidatingElementsOnLoginScreen()
        {
            Assert.IsTrue(btnLogin.Enabled);
            Assert.IsTrue(txtEmailField.Enabled);
            Assert.IsTrue(txtPasswordField.Enabled);
        }

        public void ExecuteLogin()
        {
            txtEmailField.SendKeys("luiz.test@test.com");
            txtPasswordField.SendKeys("Spice#9976thor44");
            btnLogin.Click();
            Thread.Sleep(5000);
        }


    }
}
