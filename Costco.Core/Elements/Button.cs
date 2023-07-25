using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator) { }
        public Button(IWebElement element) : base(element) { }
    }
}