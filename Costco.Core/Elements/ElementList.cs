using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costco.Core.Elements
{
    public class ElementList : BaseElement
    {
        public ElementList(By locator) : base(locator) { }
        public ElementList(IWebElement element) : base(element) { }

        public IReadOnlyCollection<IWebElement> GetElements(By selector)
        {
            return OriginalWebElement.FindElements(selector);
        }

        public bool IsEmpty()
        {
            IReadOnlyCollection<IWebElement> list = OriginalWebElement.FindElements(By.XPath("child::*"));
            return list.Count == 0;
        }
    }
}
