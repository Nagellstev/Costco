using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Costco.Utilities.Logger;

namespace Costco.Core.Browser
{
    public class Browser
    {
        private static IWebDriver? _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public static IWebDriver? Driver => _driver;

        public void Maximize()
        {
            Logger.Information("Window maximize");
            _driver.Manage().Window.Maximize();
        }

        public static void ScrollToElement(IWebElement element)
        {
            Logger.Information("Scrolling to element");
            ((IJavaScriptExecutor)_driver).
                ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetText(By locator)
        {
            return _driver.FindElement(locator).Text;
        }

        public void Back()
        {
            Logger.Information("Navigate back");
            _driver.Navigate().Back();
        }

        public void Refresh()
        {
            Logger.Information("Refresh page");
            _driver.Navigate().Refresh();
        }

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public WebDriverWait Waiter(int seconds) => new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));

        public object ExecuteScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
        }

        public void Close()
        {
            Logger.Information("Close page");
            _driver.Close();
        }

        public void Quit()
        {
            Logger.Information("Quit browser");
            _driver.Quit();
        }
    }
}
