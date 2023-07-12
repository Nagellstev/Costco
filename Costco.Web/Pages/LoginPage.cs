﻿using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class LoginPage : BasePage
    {
        public By UsernameInputFieldLocator = By.CssSelector("#signInName");
        public By PasswordInputFieldLocator = By.XPath("//input[@id='password']");
        public By LoginButtonLocator = By.XPath("//button[@type='submit']");
        public By PasswordIsRequiredErrorLocator = By.XPath("//div[@aria-hidden='false'][@class='error itemLevel']");
        public By InvalidCredentialsErrorLocator = By.XPath("//div[@aria-hidden='false'][@class='error pageLevel']");

        public InputField UsernameInputField => new InputField(UsernameInputFieldLocator);
        public InputField PasswordInputField => new InputField(PasswordInputFieldLocator);
        public Button LoginButton => new Button(LoginButtonLocator);
        public TextBox PasswordIsRequiredError => new TextBox(PasswordIsRequiredErrorLocator);
        public TextBox InvalidCredentialsError => new TextBox(InvalidCredentialsErrorLocator);
    }
}
