using OpenQA.Selenium;
using Costco.Web.Elements;
using Costco.Core.Browser;

namespace Costco.Web.Blocks
{
    public class FilterBlock : BaseBlock
    {
        public By PriceCheckBoxesLocator = By.XPath("//div[@id = 'accordion-filter_collapse-1']//span[@class='style-check ']");
        public List<CheckBox> PriceCheckBoxes;

        public FilterBlock(By locator) : base(locator) 
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