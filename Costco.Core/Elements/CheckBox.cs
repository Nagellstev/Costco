using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class CheckBox : BaseElement
    {
        public CheckBox(By locator) : base(locator) { }
        public CheckBox(IWebElement element) : base(element) { }
    }
}