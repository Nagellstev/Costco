using Costco.Utilities.FileReader;

namespace Costco.Core.Browser
{
    public static class BrowserFactory
    {
        private static ThreadLocal<Browser> _browser;
        private static ConfigModel _model;

        static BrowserFactory()
        {
            FileReader<ConfigModel> reader = new();
            _model = reader.Read(Environment.GetEnvironmentVariable("Config"));
            _browser = new ThreadLocal<Browser>(() => new Browser(DriverFactory.GetWebDriver((BrowserType)Enum.Parse(typeof(BrowserType), _model.Browser))));
        }

        public static Browser Browser
        {
            get
            {
                return _browser.Value ??= new Browser(DriverFactory.GetWebDriver((BrowserType)Enum.Parse(typeof(BrowserType), _model.Browser)));
            }
        }

        public static void CleanUp()
        {
            _browser.Value.Quit();
            _browser.Value = null;
        }
    }
}
