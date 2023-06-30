using OpenQA.Selenium;

namespace Costco.Core.Browser
{
    public interface IDriverFactory
    {
        public IWebDriver GetDriver();
    }
}
