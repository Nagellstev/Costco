using OpenQA.Selenium;

namespace Costco.Web.Elements
{
    public class CheckBox : BaseElement
    {
        public CheckBox(By locator) : base(locator)
        {

        }

        public CheckBox(IWebElement element) : base(element)
        {

        }
    }
}