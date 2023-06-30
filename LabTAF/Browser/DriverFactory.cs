using OpenQA.Selenium;

namespace LabTAF.Core.Browser
{
    public static class DriverFactory
    {
        public static IWebDriver GetWebDriver(BrowserType browserType)
        {
            IWebDriver createdWebDriver;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    createdWebDriver = new ChromeBrowser().GetDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType));
            }

            return createdWebDriver;
        }
    }
}
