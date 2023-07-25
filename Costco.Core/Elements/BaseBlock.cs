using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class BaseBlock : BaseElement
    {
        public BaseBlock(By locator) : base(locator)
        {

        }

        public BaseBlock(IWebElement element) : base(element)
        {

        }
    }
}