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
                loginPage.GoToPage();
            Thread.Sleep(10000);
                loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.False(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
                //Arrange
                LoginPage loginPage = new LoginPage();
                string userName = ((LoginCredentialsModel)testData).InvalidCredentials.Username;
                string password = ((LoginCredentialsModel)testData).InvalidCredentials.Password;

                //Action
                loginPage.GoToPage();
          //Thread.Sleep(10000);
            loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.True(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Fact]
        public void LoginWithValidUsernameButEmptyPassword()
        {
                //Arrange
                LoginPage loginPage = new LoginPage();
                string userName = ((LoginCredentialsModel)testData).InvalidCredentials.Username;
                string password = string.Empty;

                //Action
                loginPage.GoToPage();
                loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.True(loginPage.VerifyPasswordIsRequiredErrorIsDisplayed());
        }
    }
}
