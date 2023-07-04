using OpenQA.Selenium;

namespace Costco.Core.Browser
{
    public static class DriverFactory
    {
        public static IWebDriver GetWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeBrowser().GetDriver();
                case BrowserType.Firefox:
                    return new FirefoxBrowser().GetDriver();
                case BrowserType.Edge:
                    return new EdgeBrowser().GetDriver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType));
            }
        }
    }
}
