using Costco.Web.Blocks;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public By SignInButtonLocator = By.CssSelector("#header_sign_in.myaccount");
        public By DisabledSignInButtonLocator = By.XPath("//a[@class='myaccount'][@style='display: none;']");
        public override string Url => "https://www.costco.com/";
        public Button SignInButton => new Button(SignInButtonLocator);
        public Button DisabledSignInButton => new Button(DisabledSignInButtonLocator);
        public SearchBlock SearchBlock => new SearchBlock();
    }
}
