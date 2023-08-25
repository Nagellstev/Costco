using Costco.Core.Browser;
using Costco.Utilities.Screenshoter;
using Costco.Utilities.Logger;
using TechTalk.SpecFlow;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public class Hook
    {
        private ScenarioContext _scenarioContext;

        public Hook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeFeature]
        public static void Setup()
        {
            Logger.Init("Costco", TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);
            Logger.Information("Setup complete.");
        }

        [BeforeScenario]
        public void ScenarioSetup()
        {
            Logger.Information($"Initializing {_scenarioContext.ScenarioInfo.Title}.");
            BrowserFactory.Browser.Maximize();
        }

        [AfterScenario]
        public void Cleanup()
        {
            if (_scenarioContext.TestError != null)
            {
                Logger.Error($"Test '{_scenarioContext.ScenarioInfo.Title}' failed, {_scenarioContext.TestError.Message}\nException: {_scenarioContext.TestError.InnerException}");
                Screenshoter.TakeScreenshot(Browser.Driver, _scenarioContext.ScenarioInfo.Title);
            }

            BrowserFactory.CleanUp();
            Logger.Information($"{_scenarioContext.ScenarioInfo.Title} test run complete.");
        }
    }
}
