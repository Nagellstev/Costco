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

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void Back()
        {
            driver.Navigate().Back();
        }
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }
        public IWebElement FindElement(By locator)
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



        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
            instance = null;
        }
    }
}
