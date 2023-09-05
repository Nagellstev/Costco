using Reqres.Core;
using Reqres.TestData.Models;

namespace Reqres.Tests
{
    public class PavelTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public PavelTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        /// <summary>
        /// EPMFARMATS-17607 API Reqres unsuccessful login
        ///Try to login:
        ///1. with no email
        ///2. with no password
        ///3. with wrong email
        ///4. with wrong password
        ///5. with wrong email and password
        ///Expected result:
        ///1. Status 400. Response {"error": "Missing email or username"}
        ///2. Status 400. Response {"error": "Missing password"}
        ///3. Status 400.Response { "error": "User not found"}
        ///4. Status 400.Response { "error": "Wrong password"}
        ///5. Status 400.Response { "error": "User not found"}
        /// </summary>
        /*
        [Theory]
        [ClassTestData("UnsuccessfulLoginTestData.json", typeof(LoginDataModel))]
        public void UnsuccessfulLogin(LoginDataModel loginDataModel)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            string email = loginDataModel.Email;
            string password = loginDataModel.Password;
            int expectedCode = loginDataModel.ExpectedStatusCode;
            string expectedMessage = loginDataModel.ExpectedMessage;

            string body = "{\"email\": \"" + email + "\", \"password\": \"" + password + "\"}";
            var answer = client.Post("api/login", body);

            Assert.Multiple(
                () => Assert.Equal(expectedCode, (int)answer.StatusCode),
                () => Assert.Contains(expectedMessage.ToLower(), answer.Content.ToLower())
                );
        }

        [Theory]
        [ClassTestData("SuccessfulLoginTestData.json", typeof(LoginDataModel))]
        public void SuccessfulLogin(LoginDataModel loginDataModel)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            string email = loginDataModel.Email;
            string password = loginDataModel.Password;
            int expectedCode = loginDataModel.ExpectedStatusCode;
            string expectedMessage = loginDataModel.ExpectedMessage;

            string body = "{\"email\": \"" + email + "\", \"password\": \"" + password + "\"}";
            var answer = client.Post("api/login", body);

            Assert.Multiple(
                () => Assert.Equal(expectedCode, (int)answer.StatusCode),
                () => Assert.Contains(expectedMessage.ToLower(), answer.Content.ToLower())
                );
        }
        */

        [Theory]
        [InlineData("", "cityslicka", 400, "Missing email or username")]
        [InlineData("eve.holt@reqres.in", "", 400, "Missing password")]
        [InlineData("qwertyeve.holt@reqres.in", "cityslicka", 400, "User not found")]
        [InlineData("eve.holt@reqres.in", "123", 400, "Wrong password")]
        [InlineData("qwertyeve.holt@reqres.in", "1231cityslicka", 400, "User not found")]
        public void UnsuccessfulLogin(string email, string password, int expectedCode, string expectedMessage)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            string body = "{\"email\": \"" + email + "\", \"password\": \"" + password + "\"}";
            var answer = client.Post("api/login", body);

            Assert.Multiple(
                () => Assert.Equal(expectedCode, (int)answer.StatusCode),
                () => Assert.Contains(expectedMessage.ToLower(), answer.Content.ToLower())
                );
        }

        [Theory]
        [InlineData("eve.holt@reqres.in", "cityslicka", 200, "token")]
        public void SuccessfulLogin(string email, string password, int expectedCode, string expectedMessage)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            string body = "{\"email\": \"" + email + "\", \"password\": \"" + password + "\"}";
            var answer = client.Post("api/login", body);

            Assert.Multiple(
                () => Assert.Equal(expectedCode, (int)answer.StatusCode),
                () => Assert.Contains(expectedMessage.ToLower(), answer.Content.ToLower())
                );
        }

        /// <summary>
        ///EPMFARMATS-17608 API Reqres delete user
        ///try to delete user
        ///Expected result: Status 204
        /// </summary>
        [Theory]
        [InlineData(2, 204)]
        public void DeleteUser(int id, int expectedCode)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            var answer = client.Delete("/api/users/" + id, "");

            Assert.Equal(expectedCode, (int)answer.StatusCode);
        }

        /// <summary>
        ///EPMFARMATS-17609 API Reqres delayed request
        ///send get request for list of users with delay parameter
        ///get time, when request was sent
        ///get time, when response was received
        ///Expected result: response time minus request time should be greater than delay parameter
        /// </summary>
        [Theory]
        [InlineData(2, 200)]
        public void DelayedRequest(int delayInSeconds, int expectedCode)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            TimeSpan delay = TimeSpan.FromSeconds(delayInSeconds);

            DateTime requestSentAt = DateTime.Now;

            var answer = client.Get($"/api/users?delay={delay.Seconds}");

            DateTime responseGotAt = DateTime.Now;

            Assert.Multiple(
                () => Assert.Equal(expectedCode, (int)answer.StatusCode),
                () => Assert.True(responseGotAt.Subtract(requestSentAt) >= delay)
                );
        }

    }
}