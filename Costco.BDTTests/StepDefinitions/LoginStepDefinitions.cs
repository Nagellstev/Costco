
using Costco.Core.Browser;
using Costco.Web.Pages;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private MainPage _mainPage;
        private LoginPage _loginPage;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _mainPage = new();
            _loginPage = new();
        }
        [When(@"I click the sign in/register button")]
        public void WhenIClickTheSignInRegisterButton()
        {
            Waiters.WaitForCondition(() => _mainPage.SignInButton.IsEnabled());
            _mainPage.SignInButton.Click();
            Waiters.WaitForCondition(() => _loginPage.UsernameInputField.IsEnabled());
        }

        [When(@"I enter valid username and password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            _loginPage.UsernameInputField.SendKeys("tarasenko_vlad@inbox.ru");
            _loginPage.PasswordInputField.SendKeys("145698Awd$");
        }

        [When(@"I enter invalid username and password")]
        public void WhenIEnterInvalidUsernameAndPassword()
        {
            _loginPage.UsernameInputField.SendKeys("tarasenko_glad@inbox.ru");
            _loginPage.PasswordInputField.SendKeys("12345678");
        }
        [When(@"I enter valid username and empty password")]
        public void WhenIEnterValidUsernameAndEmptyPassword()
        {
            _loginPage.UsernameInputField.SendKeys("tarasenko_vlad@inbox.ru");
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            _loginPage.LoginButton.Click();
        }

        [Then(@"I should be redirected to the main page")]
        public void ThenIShouldBeRedirectedToTheMainPage()
        {
            Waiters.WaitUntilElementExists(_mainPage.AccountButtonLocator);
            _mainPage.AccountButton.Should().NotBeNull();
        }

        [Then(@"I should see '(.*)' error message")]
        public void ThenIShouldSeeErrorMessage(string error)
        {
            _loginPage.InvalidCredentialsError.Text.Should().Contain(error);
        }
        [Then(@"'(.*)' error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string error)
        {
            _loginPage.PasswordIsRequiredError.Text.Should().Contain(error);
        }
    }
}