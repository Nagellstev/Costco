using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Costco.Utilities.Logger;
using OpenQA.Selenium.Interactions;

namespace Costco.Core.Browser
{
    public class Browser
    {
        private static IWebDriver? _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
            Logger.Information($"Created new browser {driver.GetType().Name}");
        }

        public static IWebDriver? Driver => _driver;

        public void Maximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public void MoveMouseToElement(IWebElement element)
        {
            Logger.Information($"Moving mouse to {element.TagName} at {element.Location.X}:{element.Location.Y}");
            Actions act = new Actions(_driver);
            act.MoveToElement(element);
        }

        public static void ScrollToElement(IWebElement element)
        {
            Logger.Information($"Scrolling to element {element.TagName} at {element.Location.X}:{element.Location.Y}");
            ((IJavaScriptExecutor)_driver).
                ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void GoToUrl(string url)
        {
            Logger.Information($"Moving to {url}");
            _driver.Navigate().GoToUrl(url);
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetText(By locator)
        {
            Logger.Information($"Getting element text {locator.Criteria} by {locator.Mechanism}");
            return _driver.FindElement(locator).Text;
        }

        public void Back()
        {
            Logger.Information("Navigating back");
            _driver.Navigate().Back();
        }

        public void Refresh()
        {
            Logger.Information("Refreshing page");
            _driver.Navigate().Refresh();
        }

        public IWebElement FindElement(By locator)
        {
            Logger.Information($"Getting element {locator.Criteria} by {locator.Mechanism}");
            return _driver.FindElement(locator);
        }

        public List<IWebElement> FindElements(By locator)
        {
            Logger.Information($"Getting multiple elements {locator.Criteria} by {locator.Mechanism}");
            return _driver.FindElements(locator).ToList();
        }

        public WebDriverWait Waiter(int seconds)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
        }

        public void Close()
        {
            Logger.Information("Closing page");
            _driver.Close();
        }

        public void Quit()
        {
            Logger.Information("Quitting browser");
            _driver.Quit();
        }
    }
}
