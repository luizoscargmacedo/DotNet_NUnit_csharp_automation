using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace aut4CsharpNUnit.PageObject
{
    public class MenuPage
    {

        private RemoteWebDriver _driver;

        public MenuPage(RemoteWebDriver driver) => _driver = driver;

        IWebElement btnBuyNow => _driver.FindElementById("buy-button");
        IWebElement txtEnterTheirName => _driver.FindElementById("user_name");

        public void ValidatingElementsOnMenuScreen()
        {
            Assert.IsTrue(btnBuyNow.Enabled);
        }

        public void ValidateOptions()
        {
            
            // JavaScript executor
            BasicConfiguration.ExecuteJavaScript(_driver, "document.querySelector('body > app-root > app-start > div.secondary-container > div > div > div:nth-child(2) > div > div > p.secondary-card-title')");
            Thread.Sleep(5000);
            BasicConfiguration.ExecuteJavaScript(_driver, "document.querySelector('app-start > div.secondary-container > div > div > div:nth-child(3) > div > div > p.secondary-card-subtitle').click()");
            Thread.Sleep(5000);
        }

        public void ValidateInviteYourColleaguesScreen()
        {
            Assert.IsTrue(txtEnterTheirName.Enabled);
        }

    }
}
