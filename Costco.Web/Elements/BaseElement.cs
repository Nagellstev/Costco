using OpenQA.Selenium;
using Costco.Core.Browser;

namespace Costco.Web.Elements
{
    public abstract class BaseElement
    {
        private readonly IWebElement _element;

        protected BaseElement(By locator)
        {
            _element = BrowserFactory.Browser.FindElement(locator);
        }

        protected BaseElement(IWebElement element)
        {
            _element = element;
        }

        public virtual void Click()
        {
            OriginalWebElement.Click();
        }

        public void SendKeys(string keys)
        {
            OriginalWebElement.SendKeys(keys);
        }

        public void Submit ()
        {
            OriginalWebElement.Submit();
        }

        public void Clear()
        {
            OriginalWebElement.Clear();
        }

        public IWebElement OriginalWebElement => _element;
        public string Text => OriginalWebElement.Text;
        public bool IsDisplayed() => OriginalWebElement.Displayed;
        public bool IsEnabled() => OriginalWebElement.Enabled;
        public bool IsSelected() => OriginalWebElement.Selected;
        public IWebElement FindElement(By by) => OriginalWebElement.FindElement(by);
    }
}