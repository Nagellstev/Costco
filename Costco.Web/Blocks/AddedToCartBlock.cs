using OpenQA.Selenium;
using Costco.Core.Elements;
using Costco.Core.Browser;

namespace Costco.Web.Blocks
{
    public class AddedToCartBlock : BaseBlock
    {
        public readonly By ViewInCartButtonPath = By.XPath("//*[@automation-id='viewCartButton']");

        public AddedToCartBlock(By locator): base(locator) { }
        public Button ViewCart => new(ViewInCartButtonPath); 
    }
}
