using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Web.Elements;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace Costco.Web.Pages
{
    public class SearchResultsPage : BasePage
    {
        public By SearchResultsMessageLocator => By.XPath("//div[@id = 'search-results']//div[@class = 'toolbar']");
        public By TotalProductsShowingQuantityLocator => By.CssSelector("span[automation-id='totalProductsOutputText']");
        public TextBox SearchResultsMessage => new TextBox(SearchResultsMessageLocator);
        public TextBox TotalProductsShowingQuantity => new TextBox(TotalProductsShowingQuantityLocator);
        public FilterBlock FilterBlock => new FilterBlock();

        #region Search Tests Steps
        public string ReadSearchResultsMessage()
        {
            return SearchResultsMessage.Text;
        }

        public void FilterByPrice(string priceRange)
        {
            for (int i = 0; i < FilterBlock.PriceCheckBoxes.Count; i++)
            {
                if (FilterBlock.PriceCheckBoxes[i].Text.Contains(priceRange))
                {
                    FilterBlock.PriceCheckBoxes[i].Click();
                }
            }
        }

        public int CheckTotalQuantity()
        {
            string str = TotalProductsShowingQuantity.Text;
            return ExtractTotalQuantity(str);
        }

        private int ExtractTotalQuantity(string text)
        {
            //regex extracts number from the end of the string
            Regex regex = new Regex(@"\d{1,}$");
            Match match = regex.Match(text);
            return int.Parse(match.Value);
        }
        #endregion
    }
}
