using Costco.Core.Browser;
using Costco.Utilities.Screenshotter;
using Costco.Utilities.Logger;
using Costco.Web.Pages;
using Costco.Utilities.FileReader.Models;
using System.Runtime.CompilerServices;

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
                loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.False(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
            try
            {
                //Arrange
                LoginPage loginPage = new LoginPage();
                string userName = ((LoginCredentialsModel)testData).InvalidCredentials.Username;
                string password = ((LoginCredentialsModel)testData).InvalidCredentials.Password;

                //Action
                loginPage.GoToPage();
                loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.True(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshoter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }

        [Fact]
        public void LoginWithValidUsernameButEmptyPassword()
        {
            try
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
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshoter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }
    }
}
