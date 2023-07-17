using Costco.Core.Browser;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        public object testData;

        public TestFixture()
        {
            Logger.Init(DateTime.Now.ToString("dd.MM.yyyy"), TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);

            if (TestSettings.TestDataPath != null && TestSettings.TestDataPath != string.Empty)
            {
                string assemblyName = $"Costco.Utilities.FileReader.Models.{TestSettings.TestDataModel}, " +  //hack
                    $"Costco.Utilities, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"; //maybe find proper assembly name later
                FileReader reader = new();
                testData = reader.Read(TestSettings.TestDataPath, Type.GetType(assemblyName));
            }

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            BrowserFactory.CleanUp();
        }
    }
}
