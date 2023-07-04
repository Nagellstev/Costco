using OpenQA.Selenium;

namespace Costco.Core.Browser
{
    public class Browser
    {
        private static IWebDriver? _driver;
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Maximize()
        {
            _driver.Manage().Window.Maximize();
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

        public static void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
