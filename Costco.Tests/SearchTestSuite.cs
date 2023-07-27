using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshoter;
using Costco.Web.Pages;

namespace Costco.Tests
{
    [Trait("Target", "Search")]
    public class SearchTestSuite : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public SearchTestSuite(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
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
            MainPage mainPage = new MainPage();
            SearchResultsPage searchResultsPage = new SearchResultsPage();

            string searchString = ((SearchStringModel)fixture.testData).SearchString[0];
            mainPage.GoToPage();
            mainPage.SearchFieldInput(searchString);
            Waiters.WaitForCondition(() => searchResultsPage.SearchResultsMessage.IsDisplayed());
            string searchResult = searchResultsPage.ReadSearchResultsMessage();

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
            MainPage mainPage = new MainPage();
            SearchResultsPage searchResultsPage = new SearchResultsPage();

            string searchString = ((SearchStringModel)fixture.testData).SearchString[0];
            mainPage.GoToPage();
            mainPage.SearchFieldInput(searchString);
            Waiters.WaitForCondition(() => searchResultsPage.TotalProductsShowingQuantity.IsDisplayed());
            int totalQuantity = searchResultsPage.CheckTotalQuantity();
            searchResultsPage.FilterByPrice0to25();
            Waiters.WaitForPageLoad();
            Waiters.WaitForCondition(() => searchResultsPage.TotalProductsShowingQuantity.IsDisplayed());
            int totalQuantityFiltered = searchResultsPage.CheckTotalQuantity();

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
            MainPage mainPage = new MainPage();
            SearchResultsPage searchResultsPage = new SearchResultsPage();

            string searchString = ((SearchStringModel)fixture.testData).SearchString[1];
            mainPage.GoToPage();
            mainPage.SearchFieldInput(searchString);
            Waiters.WaitForCondition(() => searchResultsPage.SearchResultsMessage.IsDisplayed());
            string searchResult = searchResultsPage.ReadSearchResultsMessage();

            Assert.Contains("we were not able to find a match", searchResult.ToLower());
        }
    }
}