using OpenQA.Selenium;

namespace Costco.Web.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator) : base(locator)
        {

        }

        public TextBox(IWebElement element) : base(element)
        {

        }
    }
}