using Costco.Core.Browser;
using Costco.TestData.Models;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;
using System.Reflection;

namespace Costco.Tests
{
    public class TestFixture : IDisposable
    {
        public UrlsModel Urls;
        public object TestData;

        public TestFixture()
        {
            Logger.Init("Costco", TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);
            string urlDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Costco.TestData", "Urls.json");
            FileReader reader = new();
            Urls = (UrlsModel)reader.Read(urlDataPath, typeof(UrlsModel).AssemblyQualifiedName);
            Logger.Information("Setup complete.");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Logger.Information("Disposing of fixture.");
        }
    }
}
