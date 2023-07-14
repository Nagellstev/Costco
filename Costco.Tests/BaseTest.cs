using Costco.Core.Browser;
using Costco.Utilities.FileReader;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;
using System.Runtime.CompilerServices;


namespace Costco.Tests
{
    public class BaseTest : XunitContextBase
    {
        public object testData;
        public BaseTest(ITestOutputHelper output) : base(output)
        {
            Logger.Init(DateTime.Now.ToString("MM.dd.yyyy"), TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);

            if (TestSettings.TestDataPath != null && TestSettings.TestDataPath != string.Empty)
            {
                string assemblyName = $"Costco.Utilities.FileReader.Models.{TestSettings.TestDataModel}, " +  //hack
                    $"Costco.Utilities, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"; //maybe find proper assembly name later
                FileReader reader = new();
                testData = reader.Read(TestSettings.TestDataPath, Type.GetType(assemblyName));
            }

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
        }
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
            BrowserFactory.CleanUp();
            base.Dispose();
        }
    }
}
