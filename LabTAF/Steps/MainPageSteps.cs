using LabTAF.PageObject;
using LabTAF.SeleniumWebDriver;

namespace LabTAF.Steps
{
    public class MainPageSteps
    {
        public static void GoToPage()
        {
            Browser.Driver().Navigate().GoToUrl("https://www.costco.com/");
        }

        public static void ClickOnSignInButton()
        {
            var costcoMainPage = new CostcoMainPage();
            costcoMainPage.SignInButton.Click();
        }
    }
}
