using OpenQA.Selenium;
using Costco.Web.Elements;

namespace Costco.Web.Blocks
{
    public class FilterBlock : BaseBlock
    {
        private static readonly By filterBlockLocator = By.Id("search-filter");
        public By PriceCheckBox0to25Locator => By.XPath("//button[@id = 'accordion-filter_collapse-1']//label//span[text('$0 to $25')]");
        public CheckBox PriceCheckBox0to25 => new CheckBox(PriceCheckBox0to25Locator);
        public FilterBlock() : base(filterBlockLocator) { }
    }
}