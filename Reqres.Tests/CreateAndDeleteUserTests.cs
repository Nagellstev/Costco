using Reqres.Core;
using Reqres.TestData.Models;
using FluentAssertions;
using Costco.TestData.Models;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class CreateAndDeleteUserTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public CreateAndDeleteUserTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        /// <summary>
        ///EPMFARMATS-17608 API Reqres delete user
        ///try to delete user
        ///Expected result: Status 204
        /// </summary>
        [Theory]
        [ClassTestData("Reqres.TestData\\TestData\\DeleteUserTestData.json", typeof(DeleteUserDataModel))]
        public void DeleteUser(DeleteUserDataModel deleteUser)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            var answer = client.Delete("/api/users/" + deleteUser.UserID, "");

            int statusCode = (int)answer.StatusCode;

            statusCode.Should().Be(deleteUser.ExpectedStatusCode, $"Expected status: '{deleteUser.ExpectedStatusCode}'.");

        }
    }
}