using Reqres.Core;
using Reqres.TestData.Models;
using FluentAssertions;

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
        [Theory]
        [ClassTestData("UnsuccessfulLoginTestData.json", typeof(LoginDataModel))]
        public void UnsuccessfulLogin(LoginDataModel loginDataModel)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            string body = "{\"email\": \"" + loginDataModel.Email + "\", \"password\": \"" + loginDataModel.Password + "\"}";
            var answer = client.Post("api/login", body);

            int statusCode = (int)answer.StatusCode;
            string answerBody = answer.Content;

            Assert.Multiple(
                () => statusCode.Should().Be(loginDataModel.ExpectedStatusCode, $"Sent body: '{body}'. Expected status: '{loginDataModel.ExpectedStatusCode}'."),
                () => answerBody.ToLower().Should().Contain(loginDataModel.ExpectedMessage.ToLower(), $"Sent body: '{body}'. Expected body: '{loginDataModel.ExpectedMessage}'")
                );
        }

        /// <summary>
        ///EPMFARMATS-17608 API Reqres delete user
        ///try to delete user
        ///Expected result: Status 204
        /// </summary>
        [Theory]
        [ClassTestData("DeleteUserTestData.json", typeof(DeleteUserDataModel))]
        public void DeleteUser(DeleteUserDataModel deleteUser)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            var answer = client.Delete("/api/users/" + deleteUser.UserID, "");

            int statusCode = (int)answer.StatusCode;

            statusCode.Should().Be(deleteUser.ExpectedStatusCode, $"Expected status: '{deleteUser.ExpectedStatusCode}'.");

        }

        /// <summary>
        ///EPMFARMATS-17609 API Reqres delayed request
        ///send get request for list of users with delay parameter
        ///get time, when request was sent
        ///get time, when response was received
        ///Expected result: response time minus request time should be greater than delay parameter
        /// </summary>
        [Theory]
        [ClassTestData("DelayedRequestTestData.json", typeof(DelayedRequestDataModel))]
        public void DelayedRequest(DelayedRequestDataModel delayedRequest)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            TimeSpan delay = TimeSpan.FromSeconds(delayedRequest.Delay);

            DateTime requestSentAt = DateTime.Now;

            var answer = client.Get($"/api/users?delay={delay.Seconds}");

            DateTime responseGotAt = DateTime.Now;

            int statusCode = (int)answer.StatusCode;

            Assert.Multiple(
                () => statusCode.Should().Be(delayedRequest.ExpectedStatusCode, $"Expected status: '{delayedRequest.ExpectedStatusCode}'."),
                () => responseGotAt.Subtract(requestSentAt).Should().BeGreaterThanOrEqualTo(delay, $"Expected delay: '{delay}'.")
                );
        }
    }
}