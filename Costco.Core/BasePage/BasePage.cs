using Costco.Core.Browser;
using Costco.Utilities.Logger;
using OpenQA.Selenium;

namespace Costco.Core.BasePage
{
    public class BasePage
    {

        private IWebDriver _driver;
        public string Url { get; }

        public bool IsElementVisible(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                Logger.Error("Element wasn't found");
                return false;
            }
        }

        public bool IsPageOpened()
        {
            return BrowserFactory.Browser.GetUrl().Equals(Url);
        }
    }
}
