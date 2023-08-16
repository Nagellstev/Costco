using Costco.TestData.Models;
using Costco.Web.Steps;
using Costco.Web.Pages;

namespace Costco.Tests
{
    [Trait("Target", "Search")]
    public class SearchTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        private MainPageSteps _mainPageSteps;
        private SearchResultsPageSteps _searchResultsPageSteps;

        public SearchTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
            _mainPageSteps = new MainPageSteps(new MainPage());
            _searchResultsPageSteps = new SearchResultsPageSteps(new SearchResultsPage());
        }

        /// <summary>
        ///EPMFARMATS-17486 Search existing item
        ///1. Go to https://www.costco.com/ page
        ///2. Send keys «vitamin» to the search field
        ///result. Header of search results contains substring «vitamin»
        /// </summary>
        [Theory]
        [ClassTestData("SearchPageTestData.json", typeof(SearchPageDataModel))]
        public void SearchExistingItemTest(SearchPageDataModel searchPageDataModel)
        {
            _mainPageSteps.InputSearchQuery(searchPageDataModel.SearchExistingItem);
            string searchResult = _searchResultsPageSteps.ReadSearchResultsMessage();
            string expectedResult = searchPageDataModel.SearchExistingItemResult;

            AssertWithCustomUserMessage.Contains(expectedResult.ToLower(), searchResult.ToLower(),
                $"'{searchResult}' doesn't contain '{expectedResult}'");
        }

        /// <summary>
        ///EPMFARMATS-17487 Search existing item and sort by parameters
        ///1. Go to https://www.costco.com/ page
        ///2. Send keys «vitamin» to the search field
        ///3. Extract total quantity from string "showing 1-XX from YY"
        ///4. Choose $0 to $25 option in "Price" filter area
        ///5. Extract total quantity from string "showing 1-XX from ZZ"
        ///result. Total quantity is updated
        /// </summary>
        [Theory]
        [ClassTestData("SearchPageTestData.json", typeof(SearchPageDataModel))]
        public void SearchExistingItemAndSortByParametersTest(SearchPageDataModel searchPageDataModel)
        {
            _mainPageSteps.InputSearchQuery(searchPageDataModel.SearchExistingItemAndFilterByPriceSearch);
            int totalQuantity = _searchResultsPageSteps.GetTotalQuantity();
            _searchResultsPageSteps.FilterByPrice(searchPageDataModel.SearchExistingItemAndFilterByPriceFilter);
            int totalQuantityFiltered = _searchResultsPageSteps.GetTotalQuantity();

            AssertWithCustomUserMessage.NotEqual(totalQuantityFiltered, totalQuantity, 
                $"Total quantity '{totalQuantityFiltered}' after filtering equals to '{totalQuantity}'");
        }

        /// <summary>
        ///EPMFARMATS-17488 Search senseless line
        ///1. Go to https://www.costco.com/ page
        ///2. Send keys «qwerty» to the search field
        ///result. Header of search results contains substring «we were not able to find a match»
        /// </summary>
        [Theory]
        [ClassTestData("SearchPageTestData.json", typeof(SearchPageDataModel))]
        public void SearchSenselessLineTest(SearchPageDataModel searchPageDataModel)
        {
            _mainPageSteps.InputSearchQuery(searchPageDataModel.SearchSenselessLine);
            string expectedResult = searchPageDataModel.SearchSenselessLineResult;
            string searchResult = _searchResultsPageSteps.NothingFoundMessage();

            AssertWithCustomUserMessage.Contains(expectedResult.ToLower(), searchResult.ToLower(), 
                $"'{searchResult}' doesn't contain '{expectedResult}'");
        }
    }
}