using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Costco.Core.Browser
{
    public class FirefoxBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            var options = new FirefoxOptions();
            var service = FirefoxDriverService.CreateDefaultService();
            var driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(TestSettings.TimeOuts));
            return driver;
        }
    }
}
