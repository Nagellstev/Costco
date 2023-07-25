using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class InputField : BaseElement
    {
        public InputField(By locator) : base(locator)
        {

        }

        public InputField(IWebElement element) : base(element)
        {

        }
    }
}