using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Blocks
{
    public class ShoppingItemBlock : BaseBlock
    {
        public By ItemNamePath = By.XPath("//*[@automation-id[contains(., 'productTitleLinks')]]");
        public By ItemQuantityPath = By.XPath("//input[@automation-id[contains(., 'quantityInput')]]");

        public ShoppingItemBlock(By locator): base(locator) { }
        public ShoppingItemBlock(IWebElement element) : base(element) { }
        
        public TextBox ItemName => new(FindElement(ItemNamePath));
        public InputField ItemQuantity => new(FindElement(ItemQuantityPath));

    }
}
