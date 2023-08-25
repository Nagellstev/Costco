using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Costco.Core.Browser
{
    public static class Waiters
    {
        public static void WaitForPageLoad(int seconds = 10) => BrowserFactory.Browser.Waiter(seconds).Until(condition => BrowserFactory.Browser.ExecuteScript("return document.readyState").Equals("complete")); 
        
        public static void SetImplicitWait(int seconds = 10) => BrowserFactory.Browser.SetImplicitWait(seconds);

        public static void WaitForCondition(Func<bool> condition, int seconds = 10) => BrowserFactory.Browser.Waiter(seconds).Until(x => condition.Invoke());

        public static void WaitUntilElementExists(By locator, int seconds = 10) => BrowserFactory.Browser.Waiter(seconds).Until(ExpectedConditions.ElementExists(locator));
    }
}