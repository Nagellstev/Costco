using OpenQA.Selenium;

namespace Costco.Core.Browser
{
    public class Browser
    {
        private static Browser? instance;
        private static IWebDriver? _driver;
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        private void DriverInitialize()
        {
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).
                ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void GoToURL(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static void GoToUrlIgnoreException(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public static void BackIgnoreException()
        {
            _driver.Navigate().Back();
        }
        public static void Refresh()
        {
            _driver.Navigate().Refresh();
        }
        public static IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public static IWebDriver Driver()
        {
            if (instance == null)
            {
                instance = new Browser();
                return _driver;
            }
            return _driver;
        }



        public static void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
            instance = null;
        }
    }
}
