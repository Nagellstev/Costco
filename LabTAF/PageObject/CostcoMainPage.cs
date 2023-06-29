using OpenQA.Selenium;
using LabTAF.SeleniumWebDriver;

namespace LabTAF.PageObject
{
    public class CostcoMainPage
    {
        public IWebElement SignInButton => Browser.Driver().FindElement(By.XPath("//a[@id='header_sign_in']"));
    }
}
