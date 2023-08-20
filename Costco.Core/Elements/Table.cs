using OpenQA.Selenium;

namespace Costco.Core.Elements
{
    public class Table : BaseElement
    {
        public Table(By locator) : base(locator) { }
        public Table(IWebElement element) : base(element) { }

        public bool IsEmpty()
        {
            IReadOnlyCollection<IWebElement> rows = OriginalWebElement.FindElements(By.TagName("tr"));
            return rows.Count == 0;
        }

        public bool IsNotEmpty()
        {
            return !IsEmpty();
        }
    }
}