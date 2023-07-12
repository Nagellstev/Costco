using System.Text.RegularExpressions;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class SearchSteps
    {
        private SearchResultsPage searchResultsPage;
        private MainPage mainPage;

        public SearchSteps()
        {
            mainPage = new MainPage();
            searchResultsPage = new SearchResultsPage();
        }

        public void SearchFieldInput(string input)
        {
            mainPage.SearchBlock.SearchField.SendKeys(input);
            mainPage.SearchBlock.SearchField.Submit();
        }

        public string ReadSearchResultsMessage()
        {
            return searchResultsPage.SearchResultsMessage.Text;
        }

        public void FilterByPrice0to25()
        {
            searchResultsPage.FilterBlock.PriceCheckBox0to25.Click();
        }

        public int CheckTotalQuantity()
        {
            string str = searchResultsPage.TotalProductsShowingQuantity.Text;
            return ExtractTotalQuantity(str);
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
