using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Blocks
{
    public class DropdownOnClickSelectBlock : BaseBlock
    {
        public By ItemLocator = By.XPath("descendant::option");
        public List<TextBox> Items;

        public DropdownOnClickSelectBlock(By locator) : base(locator)
        {
            Items = GetItems();
        }

        private List<TextBox> GetItems()
        {
            List<TextBox> checkBoxes = new List<TextBox>();
            List<IWebElement> checkBoxesList = OriginalWebElement.FindElements(ItemLocator).ToList();

            foreach (IWebElement checkBox in checkBoxesList)
            {
                checkBoxes.Add(new TextBox(checkBox));
            }

            return checkBoxes;
        }
    }
}
