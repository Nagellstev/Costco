using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class ElementList : BaseElement
    {
        public ElementList(By locator) : base(locator) { }
        public ElementList(IWebElement element) : base(element) { }

        public IReadOnlyList<IWebElement> GetElements()
        {
            return OriginalWebElement.FindElements(By.CssSelector("li"));
        }

        public IWebElement? GetElementByText(string text)
        {
            foreach (var element in GetElements())
            {
                if (element.Text == text)
                {
                    return element;
                }
            }
            return null;
        }
    }
}