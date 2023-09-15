using Reqres.Core;
using Reqres.TestData.Models;
using FluentAssertions;
using Costco.TestData.Models;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class LoginTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public LoginTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
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
        [ClassTestData("Reqres.TestData\\TestData\\UnsuccessfulLoginTestData.json", typeof(LoginDataModel))]
        public void UnsuccessfulLoginTest(LoginDataModel loginDataModel)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            string body = "{\"email\": \"" + loginDataModel.Email + "\", \"password\": \"" + loginDataModel.Password + "\"}";
            var answer = client.Post("api/login", body);

            int statusCode = (int)answer.StatusCode;
            string answerBody = answer.Content;

            using (new AssertionScope())
            {
                statusCode.Should().Be(loginDataModel.ExpectedStatusCode, $"Sent body: '{body}'. Expected status: '{loginDataModel.ExpectedStatusCode}'.");
                answerBody.ToLower().Should().Contain(loginDataModel.ExpectedMessage.ToLower(), $"Sent body: '{body}'. Expected body: '{loginDataModel.ExpectedMessage}'");
            }
        }
    }
}