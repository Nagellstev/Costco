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
            _config = (ConfigModel)reader.Read("C:\\Users\\Lenovo\\source\\repos\\Costco\\Costco.TestData\\DefaultConfig.json", typeof(ConfigModel));
        }

        public static BrowserType Browser => (BrowserType)Enum.Parse(typeof(BrowserType), _config.Browser);
        public static int TimeOuts => int.Parse(_config.TimeOuts);
        public static string ApplicationUrl => _config.ApplicationUrl;
        public static string TestDataPath => _config.TestDataPath;
        public static string TestDataModel => _config.TestDataModel;
        public static string ScreenshotPath => _config.ScreenshotPath;
        public static string LoggerPath => _config.LoggerPath;

    }
}
