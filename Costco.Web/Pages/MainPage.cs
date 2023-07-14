using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public override string Url => "https://www.costco.com/";

        public By SignInButtonLocator = By.CssSelector("#header_sign_in.myaccount");
        public By DisabledSignInButtonLocator = By.XPath("//a[@class='myaccount'][@style='display: none;']");
        public Button SignInButton => new Button(SignInButtonLocator);
        public Button DisabledSignInButton => new Button(DisabledSignInButtonLocator);

        public void NavigateToLoginPage()
        {
            SignInButton.Click();
            //Waiters.WaitForPageLoad();
        }

        public bool VarifyUserIsLoggedIn()
        {
            return DisabledSignInButton.IsEnabled();
        }

        public void GoToPage()
        {
            BrowserFactory.Browser.GoToUrl(Url);
            Waiters.WaitForPageLoad();
        }

        public SearchBlock SearchBlock => new SearchBlock();

        #region Search Tests Steps
        public void SearchFieldInput(string input)
        {
            SearchBlock.SearchField.SendKeys(input);
            SearchBlock.SearchField.Submit();
        }
        #endregion
    }
}
