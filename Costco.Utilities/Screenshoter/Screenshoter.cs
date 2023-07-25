using OpenQA.Selenium;

namespace Costco.Utilities.Screenshoter
{
    public static class Screenshoter
    {
        private static string? filePath;

        public static void Init(string path)
        {
            filePath = path;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(Path.Combine(filePath, $"{testName}_{GetTimeStamp(dateTime)}.jpeg"));
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"Failed to take screenshot. Exception {ex.Message}");
            }
        }

        private static string GetTimeStamp(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd_HH-mm-ss");
    }
}