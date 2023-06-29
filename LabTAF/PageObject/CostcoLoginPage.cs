using OpenQA.Selenium;
using LabTAF.SeleniumWebDriver;

namespace LabTAF.PageObject
{
    public class CostcoLoginPage
    {
        public IWebElement UsernameField => Browser.Driver().FindElement(By.XPath("//input[@type='email']"));
        public IWebElement PasswordField => Browser.Driver().FindElement(By.XPath("//input[@type='password']"));
        public IWebElement SubmitButton => Browser.Driver().FindElement(By.XPath("//button[@type='submit']"));
    }
}
