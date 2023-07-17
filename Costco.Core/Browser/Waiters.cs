namespace Costco.Core.Browser
{
    public static class Waiters
    {
        public static void WaitForPageLoad() => BrowserFactory.Browser.Waiter(TestSettings.TimeOuts).Until(condition => BrowserFactory.Browser.ExecuteScript("return document.readyState").Equals("complete"));

        public static void WaitForCondition(Func<bool> condition, int seconds) => BrowserFactory.Browser.Waiter(seconds).Until(x => condition.Invoke());
    }
}