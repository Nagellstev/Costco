using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class LoginPage : BasePage
    {
        public override string Url => "https://www.costco.com/LogonForm";
        public readonly By usernameInputFieldLocator = By.CssSelector("#signInName");
        public readonly By passwordInputFieldLocator = By.XPath("//input[@id='password']");
        public readonly By loginButtonLocator = By.XPath("//button[@type='submit']");
        public readonly By passwordIsRequiredErrorLocator = By.XPath("//div[@aria-hidden='false'][@class='error itemLevel']");
        public readonly By invalidCredentialsErrorLocator = By.XPath("//div[@aria-hidden='false'][@class='error pageLevel']");

        public InputField UsernameInputField => new InputField(usernameInputFieldLocator);
        public InputField PasswordInputField => new InputField(passwordInputFieldLocator);
        public Button LoginButton => new Button(loginButtonLocator);
        public TextBox PasswordIsRequiredError => new TextBox(passwordIsRequiredErrorLocator);
        public TextBox InvalidCredentialsError => new TextBox(invalidCredentialsErrorLocator);

        public void LoginWithCredentials(string username, string password)
        {
            UsernameInputField.SendKeys(username);
            PasswordInputField.SendKeys(password);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(loginButtonLocator));
            LoginButton.Click();
        }

        public bool VerifyPasswordIsRequiredErrorIsDisplayed()
        {
            return PasswordIsRequiredError.IsDisplayed();
        }
        public bool VerifyInvalidCredentialsErrorIsDisplayed()
        {
            Waiters.WaitForCondition(() => InvalidCredentialsError.IsDisplayed(), 10);
            return InvalidCredentialsError.IsDisplayed();
        }
    }
}
