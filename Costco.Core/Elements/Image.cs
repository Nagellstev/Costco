using OpenQA.Selenium;

namespace Costco.Core.Elements
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