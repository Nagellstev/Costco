using Costco.Core.Browser;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        object reader;

        public TestFixture()
        {
            Logger.Init(DateTime.Now.ToString("MM.dd.yyyy"), TestSettings.LoggerPath);
            Screenshotter.Init(TestSettings.ScreenshotPath);

            Type testDataModel = Type.GetType(TestSettings.TestDataModel);
            Type fileReader = typeof(FileReader<>);
            Type constructedFileReader = fileReader.MakeGenericType(testDataModel);
            reader = Activator.CreateInstance(constructedFileReader);


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
