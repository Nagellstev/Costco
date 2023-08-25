using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class MainPageSteps
    {
        private MainPage _mainPage;

        public MainPageSteps(MainPage mainPage)
        {
            _mainPage = mainPage;
        }

        public void NavigateToLoginPage()
        {
            //Waiters.WaitForCondition(() => _mainPage.SignInButton.IsDisplayed(), 5);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(_mainPage.SignInButtonLocator));
            _mainPage.SignInButton.Click();
            //Waiters.WaitForCondition(() => new LoginPage().PasswordInputField.IsDisplayed(), 10);
        }

        public bool VerifyUserIsLoggedIn()
        {
            //Waiters.WaitForCondition(() => _mainPage.AccountButton.IsDisplayed(), 10);
            return _mainPage.AccountButton.IsDisplayed();
        }

        public void InputSearchQuery(string input)
        {
            //Waiters.WaitForCondition(() => _mainPage.SearchBlock.SearchField.IsDisplayed(), 10);
            _mainPage.SearchBlock.SearchField.SendKeys(input);
            _mainPage.SearchBlock.SearchField.Submit();
        }
    }
}
