using Costco.Core.Browser;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;
using System.Runtime.CompilerServices;


namespace Costco.Tests
{
    public class BaseTest : XunitContextBase
    {
        public object testData;
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
