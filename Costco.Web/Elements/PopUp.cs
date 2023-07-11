using OpenQA.Selenium;

namespace Costco.Web.Elements
{
    public class PopUp : BaseElement
    {
        public PopUp(By locator) : base(locator)
        {

        }

        public PopUp(IWebElement element) : base(element)
        {

        }
    }
}