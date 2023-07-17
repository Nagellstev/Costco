using Costco.Core.Browser;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;


namespace Costco.Tests
{
    public class BaseTest : XunitContextBase
    {
        public BaseTest(ITestOutputHelper output) : base(output) { }
        public override void Dispose()
        {
            
            var theExceptionThrownByTest = Context.TestException;
            var testDisplayName = Context.Test.DisplayName;

            if(theExceptionThrownByTest!= null) 
            {
                Logger.Error($"Test '{testDisplayName}' failed, exception {theExceptionThrownByTest}");
                Screenshoter.TakeScreenshot(Browser.Driver, testDisplayName);
            }

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}
