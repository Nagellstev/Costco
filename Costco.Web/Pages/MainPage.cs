using Costco.Web.Blocks;
﻿using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public readonly By SearchBlockLocator = By.Id("formcatsearch");
        public readonly By SignInButtonLocator = By.CssSelector("#header_sign_in.myaccount");
        public readonly By DisabledSignInButtonLocator = By.XPath("//a[@class='myaccount'][@style='display: none;']");
        public readonly By AccountButtonLocator = By.CssSelector("#myaccount-react-d");
        public readonly By TiresLocator = By.XPath("//div[@id='navigation-widget']//a[contains(@href,'tires')]");

        public Button TiresButton => new Button(TiresLocator);
        public Button SignInButton => new Button(SignInButtonLocator);
        public Button DisabledSignInButton => new Button(DisabledSignInButtonLocator);
        public Button AccountButton => new Button(AccountButtonLocator);
        public SearchBlock SearchBlock => new SearchBlock(SearchBlockLocator);
    }
}
