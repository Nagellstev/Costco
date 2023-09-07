
using Costco.BDTTests.Utilities;
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

        [When(@"I enter credentials")]
        public void WhenIEnterCredentials(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            _loginPage.UsernameInputField.SendKeys(dictionary["Username"]);
            _loginPage.PasswordInputField.SendKeys(dictionary["Password"]);
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
            _mainPage.AccountButton.Should().NotBeNull("because the Account button should be present on the main page");
        }

        [Then(@"I should see '(.*)' invalid credentials error message")]
        public void ThenIShouldSeeInvalidCredentialsErrorMessage(string error)
        {
            _loginPage.InvalidCredentialsError.Text.Should().Contain(error, $"because the error message should be '{error}'");
        }
        [Then(@"I sould see '(.*)' error message")]
        public void ThenISouldSeePaswordIsRequiredErrorMessage(string error)
        {
            _loginPage.PasswordIsRequiredError.Text.Should().Contain(error, $"because the error message should be '{error}'");
        }
    }
}