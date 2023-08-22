using Costco.Core.Browser;
using Costco.Utilities.Screenshoter;
using Costco.Web.Pages;
using Costco.Utilities.Logger;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class SearchStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private MainPage _mainPage;
        private SearchResultsPage _searchResultsPage;
        private decimal _totalQuantity;
        private decimal _filteredQuantity;

        public SearchStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Logger.Information($"Initializing {_scenarioContext.ScenarioInfo.Title}.");
            _mainPage = new();
            _searchResultsPage = new();
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

        [When(@"I input (.*) to the search field")]
        public void WhenIInputNameOfExistingItemToTheSearchField(string input)
        {
            Waiters.WaitForCondition(() => _mainPage.SearchBlock.SearchField.IsDisplayed(), 10);
            _mainPage.SearchBlock.SearchField.SendKeys(input);
            _mainPage.SearchBlock.SearchField.Submit();
        }

        [Then(@"I should see header containing (.*)")]
        public void ThenIShouldSeeHeaderContainingNameOfExistingItemWhichWasInputtedOnThePreviousStep(string expectedHeader)
        {
            Waiters.WaitForCondition(() => _searchResultsPage.SearchResultsMessage.IsDisplayed(), 10);
            string header = _searchResultsPage.SearchResultsMessage.Text;
            header.Should().Contain(expectedHeader);
        }

        [When(@"I get total quantity of found goods")]
        public void WhenIGetTotalQuantityOfFoundGoods()
        {
            Waiters.WaitForCondition(() => _searchResultsPage.TotalProductsShowingQuantity.IsDisplayed(), 10);
            string totalProductsShowingQuantity = _searchResultsPage.TotalProductsShowingQuantity.Text;
            _totalQuantity = ExtractTotalQuantity(totalProductsShowingQuantity);
        }

        [When(@"I filter search results by price (.*)")]
        public void WhenIFilterSearchResultsByPrice(string priceRange)
        {
            Waiters.WaitForCondition(() => _searchResultsPage.FilterBlock.IsDisplayed(), 10);
            for (int i = 0; i < _searchResultsPage.FilterBlock.PriceCheckBoxes.Count; i++)
            {
                if (_searchResultsPage.FilterBlock.PriceCheckBoxes[i].Text.Contains(priceRange))
                {
                    _searchResultsPage.FilterBlock.PriceCheckBoxes[i].Click();
                }
            }
        }

        [When(@"I get total quantity of filtered goods")]
        public void WhenIGetTotalQuantityOfFilteredGoods()
        {
            Waiters.WaitForCondition(() => _searchResultsPage.TotalProductsShowingQuantity.IsDisplayed(), 10);
            string totalProductsShowingQuantity = _searchResultsPage.TotalProductsShowingQuantity.Text;
            _filteredQuantity = ExtractTotalQuantity(totalProductsShowingQuantity);
        }

        [Then(@"Total quantity of found goods sould be greater then total quantity of filtered goods")]
        public void ThenTotalQuantityOfFoundGoodsSouldBeGreaterThenTotalQuantityOfFilteredGoods()
        {
            _totalQuantity.Should().BeGreaterThan(_filteredQuantity);
        }

        [Then(@"I should see message containing (.*)")]
        public void ThenIShouldSeeMessageContainingWeWereNotAbleToFindAMatch(string expected)
        {
            Waiters.WaitForCondition(() => _searchResultsPage.NothingFoundMessage.IsDisplayed(), 10);
            string result = _searchResultsPage.NothingFoundMessage.Text;
            result.Should().Contain(expected);
        }

        private int ExtractTotalQuantity(string text)
        {
            //regex extracts number from the end of the string
            Regex regex = new Regex(@"\d{1,}$");
            Match match = regex.Match(text);
            return int.Parse(match.Value);
        }
    }
}
