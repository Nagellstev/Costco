namespace Costco.Core.Browser
{
    public static class BrowserFactory
    {
        private static ThreadLocal<Browser> _browser;

        static BrowserFactory()
        {
            _browser = new ThreadLocal<Browser>(() => new Browser(DriverFactory.GetWebDriver(TestSettings.Browser)));
        }

        public static Browser Browser
        {
            get
            {
                return _browser.Value ??= new Browser(DriverFactory.GetWebDriver(TestSettings.Browser));
            }
        }

        public static void CleanUp()
        {
            _browser.Value.Quit();
            _browser.Value = null;
        }
    }
}
