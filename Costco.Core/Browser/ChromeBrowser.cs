using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Costco.Core.Browser
{
    public class ChromeBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var service = ChromeDriverService.CreateDefaultService();
            var driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(20));
            return driver;
        }
    }
}
