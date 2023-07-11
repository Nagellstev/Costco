using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class LoginPage : BasePage
    {
        public InputField UsernameInputField => new InputField(By.CssSelector("#signInName"));
        public InputField PasswordInputField => new InputField(By.XPath("//input[@id='password']"));
        public Button LoginButton => new Button(By.XPath("//button[@type='submit']"));
        public TextBox PasswordIsRequiredError => new TextBox(By.XPath("//div[@aria-hidden='false'][@class='error itemLevel']"));
        public TextBox InvalidCredentialsError => new TextBox(By.XPath("//div[@aria-hidden='false'][@class='error pageLevel']"));
    }
}
