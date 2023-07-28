﻿using Costco.Utilities.FileReader.Models;
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

        [Fact]
        public void LoginWithValidCredentials()
        {
            //Arrange
            string userName = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Username;
            string password = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Password;

            //Action
            _mainPageSteps.NavigateToLoginPage();
            _loginPageSteps.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(_mainPageSteps.VerifyUserIsLoggedIn());
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
            //Arrange
            string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
            string password = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Password;

            //Action
            _mainPageSteps.NavigateToLoginPage();
            _loginPageSteps.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(_loginPageSteps.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Fact]
        public void LoginWithValidUsernameButEmptyPassword()
        {
            //Arrange
            string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
            string password = string.Empty;

            //Action
            _mainPageSteps.NavigateToLoginPage();
            _loginPageSteps.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(_loginPageSteps.VerifyPasswordIsRequiredErrorIsDisplayed());
        }
    }
}
