using OpenQA.Selenium;

namespace Costco.Core.Browser
{
    public class Browser
    {
        private static Browser? instance;
        private static IWebDriver? driver;
        public Browser()
        {
            DriverInitialize();
        }

        private void DriverInitialize()
        {
            driver = BrowserFactory.GetDriver("Chrome");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).
                ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void GoToUrlIgnoreException(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void BackIgnoreException()
        {
            driver.Navigate().Back();
        }
        public static void Refresh()
        {
            driver.Navigate().Refresh();
        }
        public static IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public static IWebDriver Driver()
        {
            if (instance == null)
            {
                instance = new Browser();
                return driver;
            }
            return driver;
        }



        public static void CleanUp()
        {
            driver.Close();
            driver.Quit();
            instance = null;
        }
    }
}
