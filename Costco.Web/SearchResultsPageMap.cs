using OpenQA.Selenium;

namespace Costco.Web
{
    public class SearchResultsPageMap : BasePageMap
    {
        public By SearchResultsMessage => By.Id("rsltCntMsg");
        public By PriceFilterCheckBoxes => By.Id("accordion-filter_collapse-1");
        public By PriceCheckBox0to25 => By.XPath("//button[@id = 'accordion-filter_collapse-1']//label//span[text('$0 to $25')]");
        public By FirstPriceCheckBox => By.XPath("//span[@automation-id='filterLink_1-1']");
        public By TotalProductsShowingQuantity => By.XPath("//span[@automation-id='totalProductsOutputText']");
    }
}
