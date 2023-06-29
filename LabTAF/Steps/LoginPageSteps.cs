using LabTAF.PageObject;

namespace LabTAF.Steps
{
    public class LoginPageSteps
    {
        public static void UsernameInput(string userName)
        {
            var costcoLoginPage = new CostcoLoginPage();
            costcoLoginPage.UsernameField.SendKeys(userName);
        }

        public static void PasswordInput(string password)
        {
            var costcoLoginPage = new CostcoLoginPage();
            costcoLoginPage.PasswordField.SendKeys(password);
        }

        public static void ClickSubmitButton()
        {
            var costcoLoginPage = new CostcoLoginPage();
            costcoLoginPage.SubmitButton.Click();
        }
    }
}
