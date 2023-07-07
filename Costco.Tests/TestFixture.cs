using Costco.Core.Browser;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        public Browser browser;

        public TestFixture()
        {
            browser = BrowserFactory.Browser;
            Logger.Init(DateTime.Now.ToString("MM.dd.yyyy"), TestSettings.LoggerPath);
            Screenshotter.Init(TestSettings.ScreenshotPath);
            browser.GoToURL(TestSettings.ApplicationUrl);
            //put a waiter here?
        }

        public void Dispose() 
        {
            BrowserFactory.CleanUp();
        }
    }
}
