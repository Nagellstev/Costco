namespace Costco.Core.Browser
{
    public static class BrowserFactory
    {
        private static ThreadLocal<Browser> _browser;

        static BrowserFactory()
        {
            _browser = new ThreadLocal<Browser>(() => new Browser(DriverFactory.GetWebDriver(BrowserType.Chrome)));//Should take browser type from configuration. Fix it after adding congig reader
        }

        public static Browser Browser
        {
            get
            {
                return _browser.Value ??= new Browser(DriverFactory.GetWebDriver(BrowserType.Chrome));//Should take browser type from configuration. Fix it after adding congig reader
            }
        }

        public static void CleanUp()
        {
            _browser.Value.Quit();
            _browser.Value = null;
        }
    }
}
