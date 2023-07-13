using OpenQA.Selenium;

namespace Costco.Web.Elements
{
    public class FrameHandler : BaseElement
    {
        public FrameHandler(By locator) : base(locator)
        {

        }

        public FrameHandler(IWebElement element) : base(element)
        {

        }
    }
}