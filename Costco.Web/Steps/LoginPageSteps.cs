using Costco.Core.Browser;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class LoginPageSteps
    {
        public static void LoginWithCredentials(string username, string password)
        {
            var loginPage = new LoginPage();
            loginPage.UsernameInputField.SendKeys(username);
            loginPage.PasswordInputField.SendKeys(password);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(loginPage.LoginButtonLocator));
            loginPage.LoginButton.Click();
        }

        public static bool VerifyPasswordIsRequiredErrorIsDisplayed()
        {
            var loginPage = new LoginPage();
            return loginPage.PasswordIsRequiredError.IsDisplayed();
        }

        public static bool VerifyInvalidCredentialsErrorIsDisplayed()
        {
            var loginPage = new LoginPage();
            Waiters.WaitForCondition(() => loginPage.InvalidCredentialsError.IsDisplayed(), 10);
            return loginPage.InvalidCredentialsError.IsDisplayed();
        }
    }
}
