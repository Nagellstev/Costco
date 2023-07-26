using Costco.Core.Browser;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;
using OpenQA.Selenium;

namespace Costco.Tests
{
    public class BaseTest : XunitContextBase
    {
        string testDisplayName;

        public BaseTest(ITestOutputHelper output) : base(output) 
        {
            testDisplayName = Context.Test.DisplayName;
            Logger.Information($"Initializing {testDisplayName}.");
            BrowserFactory.Browser.Maximize();
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
        }

        public override void Dispose()
        {
            var theExceptionThrownByTest = Context.TestException;

            if(theExceptionThrownByTest!= null) 
            {
                Logger.Error($"Test '{testDisplayName}' failed, exception {theExceptionThrownByTest}.");
                Screenshoter.TakeScreenshot(Browser.Driver, testDisplayName);
            }

            GC.SuppressFinalize(this);
            base.Dispose();
            BrowserFactory.CleanUp();
            Logger.Information($"Disposing of {testDisplayName}.");
        }
    }
}
