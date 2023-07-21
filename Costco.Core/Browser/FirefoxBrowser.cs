using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Costco.Core.Browser
{
    public class FirefoxBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            var service = FirefoxDriverService.CreateDefaultService();
            var driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(TestSettings.TimeOuts));
            return driver;
        }
    }
}
