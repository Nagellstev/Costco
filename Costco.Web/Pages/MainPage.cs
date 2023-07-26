using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public override string Url => "https://www.costco.com/";
        public readonly By signInButtonLocator = By.CssSelector("#header_sign_in.myaccount");
        public readonly By disabledSignInButtonLocator = By.XPath("//a[@class='myaccount'][@style='display: none;']");
        public readonly By accountButtonLocator = By.CssSelector("#myaccount-react-d");

        public Button SignInButton => new Button(signInButtonLocator);
        public Button DisabledSignInButton => new Button(disabledSignInButtonLocator);
        public Button AccountButton => new Button(accountButtonLocator);
        public SearchBlock SearchBlock => new SearchBlock();

        public void NavigateToLoginPage()
        {
            Waiters.WaitForCondition(() => SignInButton.IsDisplayed(), 5);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(signInButtonLocator));
            SignInButton.Click();
            Waiters.WaitForCondition(() => new LoginPage().PasswordInputField.IsDisplayed(), 10);
        }

        public bool VerifyUserIsLoggedIn()
        {
            Waiters.WaitForCondition(() => AccountButton.IsDisplayed(), 10);
            return AccountButton.IsDisplayed();
        }

        #region Search Tests Steps
        public void SearchFieldInput(string input)
        {
            SearchBlock.SearchField.SendKeys(input);
            SearchBlock.SearchField.Submit();
        }
        #endregion
    }
}
