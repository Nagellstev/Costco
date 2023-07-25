using OpenQA.Selenium;

namespace Costco.Core.Elements
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