using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Costco.Core.Browser
{
    public class EdgeBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var options = new EdgeOptions();
            var service = EdgeDriverService.CreateDefaultService();
            var driver = new EdgeDriver(service, options, TimeSpan.FromSeconds(TestSettings.TimeOuts));
            return driver;
        }
    }
}
