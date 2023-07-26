using Costco.Core.Browser;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class MainPageSteps
    {
        public static void NavigateToLoginPage()
        {
            var mainPage = new MainPage();
            Waiters.WaitForCondition(() => mainPage.SignInButton.IsDisplayed(), 5);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(mainPage.SignInButtonLocator));
            mainPage.SignInButton.Click();
            Waiters.WaitForCondition(() => new LoginPage().PasswordInputField.IsDisplayed(), 10);
        }

        public static bool VerifyUserIsLoggedIn()
        {
            var mainPage = new MainPage();
            Waiters.WaitForCondition(() => mainPage.AccountButton.IsDisplayed(), 10);
            return mainPage.AccountButton.IsDisplayed();
        }
    }
}
