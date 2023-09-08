using Costco.Core.Browser;
using Costco.Web.Pages;
using Costco.Web.Blocks;

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
            _mainPage = new();
            _tiresPage = new();
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
            MenuItemClick(_tiresPage.WidthSelectBlock, width);
        }

        [When(@"I choose '(.*)' in Aspect menu")]
        public void WhenIChooseInAspectMenu(string aspect)
        {
            MenuItemClick(_tiresPage.AspectSelectBlock, aspect);
        }

        [When(@"I choose '(.*)' in Rim menu")]
        public void WhenIChooseInRimMenu(string rim)
        {
            MenuItemClick(_tiresPage.RimSelectBlock, rim);
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
            isDisplayed.Should().BeTrue("Tire center selection window should be displayed.");
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
                    Waiters.WaitForCondition(() => menu.Items[i].IsDisplayed() && menu.Items[i].IsEnabled(), 10);
                    menu.Items[i].Click();
                }
            }
        }
    }
}
