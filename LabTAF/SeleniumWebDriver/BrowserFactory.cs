using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace LabTAF.SeleniumWebDriver
{
    public static class BrowserFactory
    {
        private static IWebDriver? driver;
        public static IWebDriver GetDriver(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "CHROME":
                    {
                        driver = new ChromeDriver();
                        break;
                    }

                case "FIREFOX":
                    {
                        driver = new FirefoxDriver();
                        break;
                    }

                case "EDGE":
                    {
                        driver = new EdgeDriver();
                        break;
                    }
                default:
                    {
                        throw new Exception($"Given driver name '{browserName}' is not valid.");
                    }
            }
            return driver;
        }
    }
}
