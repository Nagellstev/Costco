﻿using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class LoginPage : BasePage
    {
        public override string Url => "https://www.costco.com/LogonForm";
        public readonly By UsernameInputFieldLocator = By.CssSelector("#signInName");
        public readonly By PasswordInputFieldLocator = By.XPath("//input[@id='password']");
        public readonly By LoginButtonLocator = By.XPath("//button[@type='submit']");
        public readonly By PasswordIsRequiredErrorLocator = By.XPath("//div[@aria-hidden='false'][@class='error itemLevel']");
        public readonly By InvalidCredentialsErrorLocator = By.XPath("//div[@aria-hidden='false'][@class='error pageLevel']");

        public InputField UsernameInputField => new InputField(UsernameInputFieldLocator);
        public InputField PasswordInputField => new InputField(PasswordInputFieldLocator);
        public Button LoginButton => new Button(LoginButtonLocator);
        public TextBox PasswordIsRequiredError => new TextBox(PasswordIsRequiredErrorLocator);
        public TextBox InvalidCredentialsError => new TextBox(InvalidCredentialsErrorLocator);

        public void LoginWithCredentials(string username, string password)
        {
            UsernameInputField.SendKeys(username);
            PasswordInputField.SendKeys(password);
            BrowserFactory.Browser.MoveMouseToElement(BrowserFactory.Browser.FindElement(LoginButtonLocator));
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
