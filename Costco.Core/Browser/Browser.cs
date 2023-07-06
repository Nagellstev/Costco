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

        public void GoToURL(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Back()
        {
            _driver.Navigate().Back();
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}
