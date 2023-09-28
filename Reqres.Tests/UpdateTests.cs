using Reqres.Core;
using FluentAssertions;
using System.Net;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class UpdateTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public UpdateTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void UpdateUsersFieldTest()
        {
            //Arrange
            Client client = builder.GetClient();
            string url = "api/users/2";
            string body = "{" +
                "\"name\": \"morpheus\", " +
                "\"job\": \"zion resident\"" +
            "}";

            //Action
            var response = client.Put(url, body);

            //Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Should().ContainAll(new string[] {
                        "\"name\":\"morpheus\"",
                        "\"job\":\"zion resident\"",
                        "updatedAt"});
            }
        }
    }
}
