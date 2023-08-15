﻿using Costco.TestData.Models;
using Costco.Web.Steps;

namespace Costco.Tests
{
    [Trait("Target", "Login")]
    public class LoginTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        private MainPageSteps _mainPageSteps;
        private LoginPageSteps _loginPageSteps;

        public LoginTests(TestFixture fixture, ITestOutputHelper output) : base(output)
        {
            this.fixture = fixture;
            _mainPageSteps = new MainPageSteps(new());
            _loginPageSteps = new LoginPageSteps(new());
        }

        [Theory]
        [ClassTestData("LoginCredentialsTestData.json", typeof(LoginCredentialsModel))]
        public void LoginWithValidCredentials(LoginCredentialsModel model)
        {
            //Arrange
            string username = model.ValidUsername;
            string password = model.ValidPassword;

            //Action
            _mainPageSteps.NavigateToLoginPage();
            _loginPageSteps.LoginWithCredentials(username, password);

            //Assert
            Assert.True(_mainPageSteps.VerifyUserIsLoggedIn());
        }

        [Theory]
        [ClassTestData("LoginCredentialsTestData.json", typeof(LoginCredentialsModel))]
        public void LoginWithInvalidCredentials(LoginCredentialsModel model)
        {
            //Arrange
            string username = model.InvalidUsername;
            string password = model.InvalidPassword;

            //Action
            _mainPageSteps.NavigateToLoginPage();
            _loginPageSteps.LoginWithCredentials(username, password);

            //Assert
            Assert.True(_loginPageSteps.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Theory]
        [ClassTestData("LoginCredentialsTestData.json", typeof(LoginCredentialsModel))]
        public void LoginWithValidUsernameButEmptyPassword(LoginCredentialsModel model)
        {
            //Arrange
            string username = model.ValidUsername;
            string password = string.Empty;

            //Action
            _mainPageSteps.NavigateToLoginPage();
            _loginPageSteps.LoginWithCredentials(username, password);

            //Assert
            Assert.True(_loginPageSteps.VerifyPasswordIsRequiredErrorIsDisplayed());
        }
    }
}
