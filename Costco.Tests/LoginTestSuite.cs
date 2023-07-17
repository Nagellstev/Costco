using Costco.Web.Pages;
using Costco.Utilities.FileReader.Models;

namespace Costco.Tests
{
    public class LoginTestSuite : BaseTest
    {
        public LoginTestSuite(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void LoginWithValidCredentials()
        {
            //Arrange
            MainPage mainPage = new MainPage();
            LoginPage loginPage = new LoginPage();
            string userName = ((LoginCredentialsModel)testData).ValidCredentials.Username;
            string password = ((LoginCredentialsModel)testData).ValidCredentials.Password;

            //Action
            mainPage.NavigateToLoginPage();
            loginPage.LoginWithCredentials(userName, password);

            //Assert
            Assert.False(mainPage.SignInButton.IsDisplayed());
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
            //Arrange
            MainPage mainPage = new MainPage();
            LoginPage loginPage = new LoginPage();
            string userName = ((LoginCredentialsModel)testData).InvalidCredentials.Username;
            string password = ((LoginCredentialsModel)testData).InvalidCredentials.Password;

            //Action
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
            string userName = ((LoginCredentialsModel)testData).InvalidCredentials.Username;
            string password = string.Empty;

            //Action
            mainPage.NavigateToLoginPage();
            loginPage.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(loginPage.VerifyPasswordIsRequiredErrorIsDisplayed());
        }
    }
}
