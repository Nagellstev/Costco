using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class RadioButton : BaseElement
    {
        public RadioButton(By locator) : base(locator)
        {

        }

        public RadioButton(IWebElement element) : base(element)
        {

        }
    }
}