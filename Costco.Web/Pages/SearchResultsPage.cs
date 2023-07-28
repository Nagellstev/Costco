using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class SearchResultsPage : BasePage
    {
        public By FilterBlockLocator = By.Id("search-filter");
        public By SearchResultsMessageLocator = By.XPath("//div[@id = 'search-results']//div[@class = 'toolbar']");
        public By TotalProductsShowingQuantityLocator = By.CssSelector("span[automation-id='totalProductsOutputText']");

        public TextBox SearchResultsMessage => new TextBox(SearchResultsMessageLocator);
        public TextBox TotalProductsShowingQuantity => new TextBox(TotalProductsShowingQuantityLocator);
        public FilterBlock FilterBlock => new FilterBlock(FilterBlockLocator);
    }
}
