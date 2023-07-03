using OpenQA.Selenium;

namespace Costco.Utilities.Screenshotter
{
    public static class Screenshotter
    {
        private static string? filePath;

        public static void Init(string path)
        {
            filePath = path;
            Directory.CreateDirectory(filePath);
        }

        public static void TakeScreenshot(IWebDriver driver)
        {
            DateTime dateTime = DateTime.Now;
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(Path.Combine(filePath, $"{GetTimeStamp(dateTime)}.jpeg"));
        }

        private static string GetTimeStamp(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd_HH-mm-ss");
    }
}