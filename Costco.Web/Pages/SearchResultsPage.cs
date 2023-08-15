using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class SearchResultsPage : BasePage
    {
        public By FilterBlockLocator = By.Id("search-filter");
        public By SearchResultsMessageLocator = By.Id("search-results");
        public By NothingFoundMessageLocator = By.Id("no-results");
        public By TotalProductsShowingQuantityLocator = By.CssSelector("span[automation-id='totalProductsOutputText']");

        public TextBox SearchResultsMessage => new TextBox(SearchResultsMessageLocator);
        public TextBox NothingFoundMessage => new TextBox(NothingFoundMessageLocator);
        public TextBox TotalProductsShowingQuantity => new TextBox(TotalProductsShowingQuantityLocator);
        public FilterBlock FilterBlock => new FilterBlock(FilterBlockLocator);
    }
}
