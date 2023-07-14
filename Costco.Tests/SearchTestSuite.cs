using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;
using Costco.Web.Pages;

namespace Costco.Tests
{
    public class SearchTestSuite : IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public SearchTestSuite(TestFixture fixture)
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
        public void SearchExistingItem()
        {
            try
            {
                MainPage mainPage = new MainPage();
                SearchResultsPage searchResultsPage = new SearchResultsPage();

                string searchString = ((SearchStringModel)fixture.testData).SearchString[0];
                mainPage.SearchFieldInput(searchString);
                Waiters.WaitForCondition(() => searchResultsPage.SearchResultsMessage.IsDisplayed(), 5);                
                string searchResult = searchResultsPage.ReadSearchResultsMessage();

                Assert.Contains(searchString.ToLower(), searchResult.ToLower());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }

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
        public void SearchExistingItemAndSortByParameters()
        {
            try
            {
                MainPage mainPage = new MainPage();
                SearchResultsPage searchResultsPage = new SearchResultsPage();

                string searchString = ((SearchStringModel)fixture.testData).SearchString[0];
                mainPage.SearchFieldInput(searchString);
                Waiters.WaitForCondition(() => searchResultsPage.TotalProductsShowingQuantity.IsDisplayed(), 5);
                int totalQuantity = searchResultsPage.CheckTotalQuantity();
                searchResultsPage.FilterByPrice0to25();
                Waiters.WaitForPageLoad();
                Waiters.WaitForCondition(() => searchResultsPage.TotalProductsShowingQuantity.IsDisplayed(), 5);
                int totalQuantityFiltered = searchResultsPage.CheckTotalQuantity();

                Assert.NotEqual(totalQuantityFiltered, totalQuantity);
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }

        /// <summary>
        ///EPMFARMATS-17488 Search senseless line
        ///1. Go to https://www.costco.com/ page
        ///2. Send keys «qwerty» to the search field
        ///result. Header of search results contains substring «we were not able to find a match»
        /// </summary>
        [Fact]
        public void SearchSenselessLine()
        {
            try
            {
                MainPage mainPage = new MainPage();
                SearchResultsPage searchResultsPage = new SearchResultsPage();

                string searchString = ((SearchStringModel)fixture.testData).SearchString[1];
                mainPage.SearchFieldInput(searchString);
                Waiters.WaitForCondition(() => searchResultsPage.SearchResultsMessage.IsDisplayed(), 5);
                string searchResult = searchResultsPage.ReadSearchResultsMessage();

                Assert.Contains("we were not able to find a match", searchResult.ToLower());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }
    }
}