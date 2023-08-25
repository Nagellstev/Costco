using OpenQA.Selenium;
using Costco.Core.Browser;
using OpenQA.Selenium.Interactions;

namespace Costco.Core.Elements
{
    public abstract class BaseElement
    {
        private readonly IWebElement _element;

        protected BaseElement(By locator)
        {
            _element = BrowserFactory.Browser.FindElement(locator);
        }

        public IWebElement OriginalWebElement => _element;
        public string Text => OriginalWebElement.Text;

        protected BaseElement(IWebElement element)
        {
            _element = element;
        }

        public virtual void Click()
        {
            OriginalWebElement.Click();
        }

        public void Hover()
        {
            Actions actions = new Actions(Browser.Browser.Driver);
            actions.MoveToElement(OriginalWebElement).Perform();
        }

        public void SendKeys(string keys)
        {
            OriginalWebElement.SendKeys(keys);
        }

        public void Submit()
        {
            OriginalWebElement.Submit();
        }

        public void Clear()
        {
            OriginalWebElement.Clear();
        }

        public bool IsDisplayed()
        {
            return OriginalWebElement.Displayed;
        }

        public bool IsEnabled()
        {
            return OriginalWebElement.Enabled;
        }

        public bool IsSelected()
        {
            return OriginalWebElement.Selected;
        }

        public IWebElement FindElement(By by)
        {
            return OriginalWebElement.FindElement(by);
        }
    }
}