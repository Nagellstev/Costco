using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class SearchResultsPage : BasePage
    {
        public By SearchResultsMessageLocator => By.Id("rsltCntMsg");
        public TextBox SearchResultsMessage => new TextBox(SearchResultsMessageLocator);
        public By PriceCheckBox0to25Locator => By.XPath("//button[@id = 'accordion-filter_collapse-1']//label//span[text('$0 to $25')]");
        public CheckBox PriceCheckBox0to25 => new CheckBox(PriceCheckBox0to25Locator);
        public By TotalProductsShowingQuantityLocator => By.CssSelector("span[automation-id='totalProductsOutputText']");
        public TextBox TotalProductsShowingQuantity => new TextBox(TotalProductsShowingQuantityLocator);
    }
}
