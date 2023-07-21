using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace Costco.Core.Browser
{
    public class ChromeBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            List<string> ls = new List<string>();
            ls.Add("excludeSwitches");
            ls.Add("enable-automation");
            var options = new ChromeOptions();
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-extensions");
            options.AddAdditionalChromeOption("useAutomationExtension", false);
            options.AddExcludedArguments(ls);
            options.AddArgument("--no-sandbox");
            //options.AddArgument("headless");
            options.AddArgument("ignore-certificate-errors");
            options.Proxy = new Proxy()
            {
                Kind = ProxyKind.Direct
            };
            options.AddArgument("--start-maximized");
            var service = ChromeDriverService.CreateDefaultService();
            var driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(120));
            WebRequest.DefaultWebProxy = null;
            HttpClient.DefaultProxy = new WebProxy()
            {
                BypassProxyOnLocal = true,
            };
            return driver;
        }
    }
}
