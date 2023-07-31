using Costco.Web.Blocks;
﻿using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public readonly By SignInButtonLocator = By.CssSelector("#header_sign_in.myaccount");
        public readonly By DisabledSignInButtonLocator = By.XPath("//a[@class='myaccount'][@style='display: none;']");
        public readonly By AccountButtonLocator = By.CssSelector("#myaccount-react-d");

        public Button SignInButton => new Button(SignInButtonLocator);
        public Button DisabledSignInButton => new Button(DisabledSignInButtonLocator);
        public Button AccountButton => new Button(AccountButtonLocator);
        public SearchBlock SearchBlock => new SearchBlock();

        public void NavigateToLoginPage()
        {
            Waiters.WaitForCondition(() => SignInButton.IsDisplayed());
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(SignInButtonLocator));
            SignInButton.Click();
            Waiters.WaitForCondition(() => new LoginPage().PasswordInputField.IsDisplayed());
        }

        public bool VerifyUserIsLoggedIn()
        {
            Waiters.WaitForCondition(() => AccountButton.IsDisplayed());
            return AccountButton.IsDisplayed();
        }
    }
}
