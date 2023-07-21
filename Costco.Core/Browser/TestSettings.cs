using Costco.Utilities.FileReader;
using Costco.Utilities.FileReader.Models;

namespace Costco.Core.Browser
{
    public static class TestSettings
    {
        private static ConfigModel _config;

        static TestSettings()
        {
            FileReader reader = new();
            _config = (ConfigModel)reader.Read(Environment.GetEnvironmentVariable("Config"));
        }

        public static BrowserType Browser => (BrowserType)Enum.Parse(typeof(BrowserType), _config.Browser);
        public static double TimeOuts => double.Parse(_config.TimeOuts);
        public static int TestWaits => int.Parse(_config.TestWaits);
        public static string ApplicationUrl => _config.ApplicationUrl;
        public static string ScreenshotPath => _config.ScreenshotPath;
        public static string LoggerPath => _config.LoggerPath;

    }
}
