using Costco.Web.Pages;
using Costco.Utilities.FileReader.Models;
using Costco.Core.Browser;
using Costco.Web.Steps;

namespace Costco.Tests
{
    [Trait("Target", "Login")]
    public class LoginTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        public LoginTests(TestFixture fixture, ITestOutputHelper output) : base(output)
        {
            this.fixture= fixture;
        }

        [Fact]
        public void LoginWithValidCredentials()
        {
            //Arrange
            string userName = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Username;
            string password = ((LoginCredentialsModel)fixture.testData).ValidCredentials.Password;

            //Action
            MainPageSteps.NavigateToLoginPage();
            LoginPageSteps.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(MainPageSteps.VerifyUserIsLoggedIn());
        }

        [Fact]
        public void LoginWithInvalidCredentials()
        {
            //Arrange
            string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
            string password = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Password;

            //Action
            MainPageSteps.NavigateToLoginPage();
            LoginPageSteps.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(LoginPageSteps.VerifyInvalidCredentialsErrorIsDisplayed());
        }

        [Fact]
        public void LoginWithValidUsernameButEmptyPassword()
        {
            //Arrange
            string userName = ((LoginCredentialsModel)fixture.testData).InvalidCredentials.Username;
            string password = string.Empty;

            //Action
            MainPageSteps.NavigateToLoginPage();
            LoginPageSteps.LoginWithCredentials(userName, password);

            //Assert
            Assert.True(LoginPageSteps.VerifyPasswordIsRequiredErrorIsDisplayed());
        }
    }
}
