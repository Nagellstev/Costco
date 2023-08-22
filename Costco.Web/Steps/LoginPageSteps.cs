using Costco.Core.Browser;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class LoginPageSteps
    {
        private LoginPage _loginPage;

        public LoginPageSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        public void LoginWithCredentials(string username, string password)
        {
            _loginPage.UsernameInputField.SendKeys(username);
            _loginPage.PasswordInputField.SendKeys(password);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(_loginPage.LoginButtonLocator));
            _loginPage.LoginButton.Click();
        }

        public bool VerifyPasswordIsRequiredErrorIsDisplayed()
        {
            return _loginPage.PasswordIsRequiredError.IsDisplayed();
        }

        public bool VerifyInvalidCredentialsErrorIsDisplayed()
        {
            //Waiters.WaitForCondition(() => _loginPage.InvalidCredentialsError.IsDisplayed(), 10);
            return _loginPage.InvalidCredentialsError.IsDisplayed();
        }
    }
}
