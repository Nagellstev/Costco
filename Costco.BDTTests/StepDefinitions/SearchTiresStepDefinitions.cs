using Costco.Core.Browser;
using Costco.Utilities.Screenshoter;
using Costco.Web.Pages;
using Costco.Utilities.Logger;
using TechTalk.SpecFlow;
using Costco.Web.Blocks;
using Xunit;
using Costco.Web.Steps;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public class SearchTiresStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private MainPage _mainPage;
        private TiresPage _tiresPage;

        public SearchTiresStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Logger.Information($"Initializing {_scenarioContext.ScenarioInfo.Title}.");
            _mainPage = new();
            _tiresPage = new();
            BrowserFactory.Browser.Maximize();
        }

        [BeforeFeature]
        public static void Setup()
        {
            Logger.Init("Costco", TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);
            Logger.Information("Setup complete.");
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
            Logger.Information($"Disposing of {_scenarioContext.ScenarioInfo.Title}.");
        }

        [Given(@"I opened the page '(.*)'")]
        public void GivenIOpenedThePage(string url)
        {
            BrowserFactory.Browser.GoToUrl(url);
        }

        [When(@"I press button Tires")]
        public void WhenIPressButtonTires()
        {
            _mainPage.TiresButton.Click();
        }

        [When(@"I press button Search by size")]
        public void WhenIPressButtonSearchBySize()
        {
            Waiters.WaitForCondition(() => _tiresPage.SearchBySizeButton.IsDisplayed(), 10);
            _tiresPage.SearchBySizeButton.Click();
        }

        [When(@"I press button Accept all cookies")]
        public void WhenIPressButtonAcceptAllCookies()
        {
            Waiters.WaitForCondition(() => _tiresPage.AcceptAllCookiesButton.IsDisplayed(), 10);
            _tiresPage.AcceptAllCookiesButton.Click();
        }

        [When(@"I choose '(.*)' in Width menu")]
        public void WhenIChooseInWidthMenu(string width)
        {
            Thread.Sleep(500);
            MenuItemClick(_tiresPage.WidthSelectBlock, width);
            Thread.Sleep(500);
        }

        [When(@"I choose '(.*)' in Aspect menu")]
        public void WhenIChooseInAspectMenu(string aspect)
        {
            Thread.Sleep(500);
            MenuItemClick(_tiresPage.AspectSelectBlock, aspect);
            Thread.Sleep(500);
        }

        [When(@"I choose '(.*)' in Rim menu")]
        public void WhenIChooseInRimMenu(string rim)
        {
            Thread.Sleep(500);
            MenuItemClick(_tiresPage.RimSelectBlock, rim);
            Thread.Sleep(500);
        }

        [When(@"I input '(.*)' to postal code line")]
        public void WhenIInputToPostalCodeLine(string code)
        {
            Waiters.WaitForCondition(() => _tiresPage.PostalCodeInput.IsDisplayed(), 10);
            _tiresPage.PostalCodeInput.SendKeys(code);
        }

        [When(@"I press button Find tires")]
        public void WhenIPressButtonFindTires()
        {
            Waiters.WaitForCondition(() => _tiresPage.FindTiresButton.IsDisplayed(), 5);
            _tiresPage.FindTiresButton.Click();
        }

        [Then(@"I should see window with selection of tire center")]
        public void ThenIShouldSeeWindowWithSelectionOfTireCenter()
        {
            Waiters.WaitForCondition(() => _tiresPage.SelectTireCenterLabel.IsDisplayed(), 5);
            bool isDisplayed =  _tiresPage.SelectTireCenterLabel.IsDisplayed();
            isDisplayed.Should().BeTrue();
        }

        private void MenuItemClick(DropdownOnClickSelectBlock menu, string item)
        {
            Waiters.WaitForCondition(() => menu.IsDisplayed() && menu.IsEnabled(), 10);
            menu.OriginalWebElement.Click();
            Waiters.WaitForCondition(() => menu.Items.Count > 0, 10);
            for (int i = 0; i < menu.Items.Count; i++)
            {
                if (menu.Items[i].Text.Contains(item))
                {
                    menu.Items[i].Click();
                }
            }
        }
    }
}
