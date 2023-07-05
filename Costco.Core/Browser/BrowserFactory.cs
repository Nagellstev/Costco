namespace Costco.Core.Browser
{
    public static class BrowserFactory
    {
        private static ThreadLocal<Browser> _driver;

        static BrowserFactory()
        {
            _driver = new ThreadLocal<Browser>(() => new Browser(DriverFactory.GetWebDriver(BrowserType)));
        }

        public static Browser Browser
        {
            get
            {
                return _driver.Value ??= new Browser(DriverFactory.GetWebDriver(BrowserType));
            }
        }

        public static void CleanUp()
        {
            _driver.Value.Quit();
            _driver.Value = null;
        }
    }
}
