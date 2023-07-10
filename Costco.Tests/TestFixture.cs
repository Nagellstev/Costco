using Costco.Core.Browser;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        //TestData testData;

        public TestFixture()
        {
            Logger.Init(DateTime.Now.ToString("MM.dd.yyyy"), TestSettings.LoggerPath);
            Screenshotter.Init(TestSettings.ScreenshotPath);
            //FileReader<TestData> reader = new();
            //testData = reader<TestData>.Read(TestSettings.TestDataPath);
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
