using Costco.Core.Browser;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        //shared test data goes here 

        public TestFixture()
        {
            Logger.Init(DateTime.Now.ToString("MM.dd.yyyy"), TestSettings.LoggerPath);
            Screenshotter.Init(TestSettings.ScreenshotPath);
            BrowserFactory.Browser.GoToURL(TestSettings.ApplicationUrl);
            //put a waiter here?
        }

        public void Dispose() 
        {
            GC.SuppressFinalize(this);
            BrowserFactory.CleanUp();
        }
    }
}
