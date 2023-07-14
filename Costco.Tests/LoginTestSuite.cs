using Costco.Core.Browser;
using Costco.Utilities.Screenshotter;
using Costco.Utilities.Logger;
using Costco.Web.Pages;
using Costco.Utilities.FileReader.Models;

namespace Costco.Tests
{
    public class LoginTestSuite : IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public LoginTestSuite(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void LoginWithValidCredentials()
        {
            try
            {
                //Arrange
                MainPage mainPage = new MainPage();
                LoginPage loginPage = new LoginPage();
                string userName = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Username;
                string password = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Password;

                //Action
                loginPage.GoToPage();
                loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.False(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
            try
            {
                //Arrange
                LoginPage loginPage = new LoginPage();
                string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
                string password = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Password;

                //Action
                loginPage.GoToPage();
                loginPage.LoginWithCredentials(userName, password);

                //Assert
                Assert.True(loginPage.VerifyInvalidCredentialsErrorIsDisplayed());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
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
                string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
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
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }
    }
}
