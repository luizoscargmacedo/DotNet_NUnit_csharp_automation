using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;


namespace aut4CsharpNUnit
{
    class BasicConfiguration
    {
        #region Browser
        public static RemoteWebDriver GetBrowserLocal(RemoteWebDriver driver, String browser)
        {
            switch (browser)
            {
                /* case "Firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "Safari":
                    driver = new SafariDriver();
                    driver.Manage().Window.Maximize();
                    break; */
                default:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }
        #endregion


        public static RemoteWebDriver GetBrowserRemote(RemoteWebDriver driver, String browser, String uri)
        {
            switch (browser)
            {
                /* case "Safari":
                    SafariOptions opt_safari = new SafariOptions();
                    driver = new RemoteWebDriver(new Uri(uri), opt_safari);
                    driver.Manage().Window.Maximize();
                    break;
                case "Firefox":
                    FirefoxOptions opt_firefox = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri(uri), opt_firefox);
                    driver.Manage().Window.Maximize();
                    break; */
                default:
                    ChromeOptions opt_chrome = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri(uri), opt_chrome);
                    driver.Manage().Window.Maximize();
                    break;
                
            }
            return driver;
        }

        #region JavaScript
        public static void ExecuteJavaScript(RemoteWebDriver driver, String script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        } 
        #endregion

    }
}
