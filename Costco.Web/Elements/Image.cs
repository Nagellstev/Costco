using OpenQA.Selenium;

namespace Costco.Web.Elements
{
    public class Image : BaseElement
    {
        public Image(By locator) : base(locator)
        {

        }

        public Image(IWebElement element) : base(element)
        {

        }
    }
}