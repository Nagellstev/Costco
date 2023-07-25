using Costco.Core.Browser;
using Costco.Core.ConfigurationModels;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;
using System.Reflection;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        public object testData;

        public TestFixture()
        {
            Logger.Init("Costco", TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);
            string testDataPath = Environment.GetEnvironmentVariable("TestData");

            if (testDataPath!= null)
            {
                FileReader reader = new();
                testData = reader.Read(testDataPath, AssemblyName.GetAssemblyName("Costco.TestData.dll").FullName);
                Logger.Information($"Reading test data {testDataPath}.");
            }

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
            Logger.Information("Setup complete.");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            BrowserFactory.CleanUp();
            Logger.Information("Disposing of fixture.");
        }
    }
}
