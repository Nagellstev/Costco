using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Costco.Core.Browser
{
    public class EdgeBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var options = new EdgeOptions();
            var service = EdgeDriverService.CreateDefaultService();
            var driver = new EdgeDriver(service, options, TimeSpan.FromSeconds(TestSettings.TimeOuts));
            return driver;
        }
    }
}
