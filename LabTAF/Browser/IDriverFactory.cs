using OpenQA.Selenium;

namespace LabTAF.Core.Browser
{
    public interface IDriverFactory
    {
        public IWebDriver GetDriver();
    }
}
