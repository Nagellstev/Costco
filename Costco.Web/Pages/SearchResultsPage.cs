using Costco.Web.Blocks;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class SearchResultsPage : BasePage
    {
        public By SearchResultsMessageLocator => By.Id("rsltCntMsg");
        public TextBox SearchResultsMessage => new TextBox(SearchResultsMessageLocator);
        public By TotalProductsShowingQuantityLocator => By.CssSelector("span[automation-id='totalProductsOutputText']");
        public TextBox TotalProductsShowingQuantity => new TextBox(TotalProductsShowingQuantityLocator);
        public FilterBlock FilterBlock => new FilterBlock();
    }
}
