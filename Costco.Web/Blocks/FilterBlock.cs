using OpenQA.Selenium;
using Costco.Web.Elements;
using Costco.Core.Browser;

namespace Costco.Web.Blocks
{
    public class FilterBlock : BaseBlock
    {
        public static By FilterBlockLocator => By.Id("search-filter");
        public By PriceCheckBoxesLocator => By.XPath("//div[@id = 'accordion-filter_collapse-1']//span[@class='style-check ']");
        public List<CheckBox> PriceCheckBoxes;

        public FilterBlock() : base(FilterBlockLocator) 
        { 
            PriceCheckBoxes = GetCheckBoxes();
        }

        private List<CheckBox> GetCheckBoxes()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            List<IWebElement> checkBoxesList = BrowserFactory.Browser.FindElements(PriceCheckBoxesLocator); ;
            
            foreach (IWebElement checkBox in checkBoxesList)
            {
                checkBoxes.Add(new CheckBox(checkBox));
            }

            return checkBoxes;
        }
    }
}