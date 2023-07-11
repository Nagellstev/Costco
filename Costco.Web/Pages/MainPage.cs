using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPage : BasePage
    {
        public override string Url => "https://www.costco.com/";
        public Button SignInButton => new Button(By.CssSelector("#header_sign_in.myaccount"));
        public Button AccountButton => new Button(By.CssSelector("#myaccount-react-d"));
    }
}
