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
        [Fact]
        public void SearchExistingItemTest()
        {
            string searchString = ((SearchStringModel)fixture.TestData).SearchString[0];

            _mainPageSteps.SearchFieldInput(searchString);
            string searchResult = _searchResultsPageSteps.ReadSearchResultsMessage();

            Assert.Contains(searchString.ToLower(), searchResult.ToLower());
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
        [Fact]
        public void SearchExistingItemAndSortByParametersTest()
        {
            string searchString = ((SearchStringModel)fixture.TestData).SearchString[0];
            string priceFilter = ((SearchStringModel)fixture.TestData).PriceFilters[0];

            _mainPageSteps.SearchFieldInput(searchString);
            int totalQuantity = _searchResultsPageSteps.GetTotalQuantity();
            _searchResultsPageSteps.FilterByPrice(priceFilter);
            int totalQuantityFiltered = _searchResultsPageSteps.GetTotalQuantity();

            Assert.NotEqual(totalQuantityFiltered, totalQuantity);
        }

        /// <summary>
        ///EPMFARMATS-17488 Search senseless line
        ///1. Go to https://www.costco.com/ page
        ///2. Send keys «qwerty» to the search field
        ///result. Header of search results contains substring «we were not able to find a match»
        /// </summary>
        [Fact]
        public void SearchSenselessLineTest()
        {
            string searchString = ((SearchStringModel)fixture.TestData).SearchString[1];

            _mainPageSteps.SearchFieldInput(searchString);
            string searchResult = _searchResultsPageSteps.ReadSearchResultsMessage();

            Assert.Contains("we were not able to find a match", searchResult.ToLower());
        }
    }
}