using System.Text.RegularExpressions;

namespace Costco.Web
{
    public class SearchResultsPage
    {
        public BasePageMap pageMap;

        public SearchResultsPage()
        {
            pageMap = new SearchResultsPageMap();
        }

        public string ReadSearchResultsMessage()
        {
            return "";// read text from webElement found by SearchResultsPageMap.SearchResultsMessage
        }

        public void FilterByPrice0to25()
        {
            // click webElement found by SearchResultsPageMap.PriceCheckBox0to25
        }

        public int CheckTotalQuantity()
        {
            string str = "Showing 1-24 of 74";// read text webElement found by SearchResultsPageMap.TotalProductsShowingQuantity.Text
            return ExtractTotalQuantity(str);
        }

        private int ExtractTotalQuantity(string text)
        {
            //extract number from the end of the string
            Regex regex = new Regex(@"\d{1,}$");
            Match match = regex.Match(text);
            return Int32.Parse(match.Value);
        }
    }
}
