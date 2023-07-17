using Costco.Web.Pages;
using Costco.Utilities.FileReader.Models;
using Costco.Core.Browser;

namespace Costco.Tests
{
    public class LoginTestSuite : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        public LoginTestSuite(TestFixture fixture, ITestOutputHelper output) : base(output)
        {
            this.fixture= fixture;
        }

        [Fact]
        public void LoginWithValidCredentials()
        {
            //Arrange
            MainPage mainPage = new MainPage();
            LoginPage loginPage = new LoginPage();
            string userName = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Username;
            string password = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Password;

            //Action
            mainPage.NavigateToLoginPage();
            loginPage.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(mainPage.VerifyUserIsLoggedIn());
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
            //Arrange
            MainPage mainPage = new MainPage();
            LoginPage loginPage = new LoginPage();
            string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
            string password = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Password;

            //Action
            mainPage.GoToPage();
            mainPage.NavigateToLoginPage();
            loginPage.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Fact]
        public void LoginWithValidUsernameButEmptyPassword()
        {
            //Arrange
            MainPage mainPage = new MainPage();
            LoginPage loginPage = new LoginPage();
            string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
            string password = string.Empty;

            //Action
            mainPage.NavigateToLoginPage();
            loginPage.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(loginPage.VerifyPasswordIsRequiredErrorIsDisplayed());
        }
    }
}
