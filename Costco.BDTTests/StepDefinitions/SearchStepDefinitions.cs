using Costco.Core.Browser;
using Costco.Web.Pages;
using System.Text.RegularExpressions;

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
            _mainPage = new();
            _searchResultsPage = new();
        }

        [When(@"I input '(.*)' to the search field and submit my search query")]
        public void WhenIInputNameOfExistingItemToTheSearchField(string input)
        {
            Waiters.WaitForCondition(() => _mainPage.SearchBlock.SearchField.IsDisplayed(), 10);
            _mainPage.SearchBlock.SearchField.SendKeys(input);
            _mainPage.SearchBlock.SearchField.Submit();
        }

        [Then(@"I should see header above found goods containing '(.*)'")]
        public void ThenIShouldSeeHeaderContainingNameOfExistingItemWhichWasInputtedOnThePreviousStep(string expectedHeader)
        {
            Waiters.WaitForCondition(() => _searchResultsPage.SearchResultsMessage.IsDisplayed(), 10);
            string header = _searchResultsPage.SearchResultsMessage.Text.ToLower();
            header.Should().Contain(expectedHeader.ToLower(), $"Header above found goods is '{header}', it does not contain '{expectedHeader}', but it should.");
        }

        [When(@"I get total quantity of found goods")]
        public void WhenIGetTotalQuantityOfFoundGoods()
        {
            Waiters.WaitForCondition(() => _searchResultsPage.TotalProductsShowingQuantity.IsDisplayed(), 10);
            string totalProductsShowingQuantity = _searchResultsPage.TotalProductsShowingQuantity.Text;
            _totalQuantity = ExtractTotalQuantity(totalProductsShowingQuantity);
        }

        [When(@"I filter search results by price '(.*)'")]
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

        [Then(@"Total quantity of found goods should be greater than total quantity of filtered goods")]
        public void ThenTotalQuantityOfFoundGoodsShouldBeGreaterThanTotalQuantityOfFilteredGoods()
        {
            _totalQuantity.Should().BeGreaterThan(_filteredQuantity, $"Total quantity of found goods should be greater than total quantity of filtered goods. Total quantity: {_totalQuantity}; filtered quantity: {_filteredQuantity}");
        }

        [Then(@"I should see header on the page containing ""we were not able to find a match""")]
        public void ThenIShouldSeeMessageContainingWeWereNotAbleToFindAMatch()
        {
            string expected = "we were not able to find a match";
            Waiters.WaitForCondition(() => _searchResultsPage.NothingFoundMessage.IsDisplayed(), 10);
            string result = _searchResultsPage.NothingFoundMessage.Text.ToLower();
            result.Should().Contain(expected.ToLower(), $"If there is nothing found, header on the page should contain '{expected}', but it does not.");
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
