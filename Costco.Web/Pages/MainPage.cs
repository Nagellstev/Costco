using Costco.Web.Blocks;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public By SearchBlockLocator = By.Id("formcatsearch");
        public By SignInButtonLocator = By.CssSelector("#header_sign_in.myaccount");
        public By DisabledSignInButtonLocator = By.XPath("//a[@class='myaccount'][@style='display: none;']");
        public By AccountButtonLocator = By.CssSelector("#myaccount-react-d");
        public Button SignInButton => new Button(SignInButtonLocator);
        public Button DisabledSignInButton => new Button(DisabledSignInButtonLocator);
        public Button AccountButton => new Button(AccountButtonLocator);
        public SearchBlock SearchBlock => new SearchBlock(SearchBlockLocator);
    }
}
