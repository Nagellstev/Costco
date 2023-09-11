using Reqres.Core;
using FluentAssertions;
using System.Net;

namespace Reqres.Tests
{
    public class VladTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public VladTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetNonExistentUser()
        {
            //Arrange
            Client client = builder.GetClient();
            string url = "api/users/23";

            //Action
            var response = client.Get(url);

            //Assert
            Assert.Multiple(
                () => response.StatusCode.Should().Be(HttpStatusCode.NotFound),
                () => response.Content.Should().Be("{}"));
        }

        [Fact]
        public void GetNonExistentResource()
        {
            //Arrange
            Client client = builder.GetClient();
            string url = "api/unknown/23";

            //Action
            var response = client.Get(url);

            //Assert
            Assert.Multiple(
                () => response.StatusCode.Should().Be(HttpStatusCode.NotFound),
                () => response.Content.Should().Be("{}"));
        }

        [Fact]
        public void UpdateUsersName()
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
            Assert.Multiple(
                () => response.StatusCode.Should().Be(HttpStatusCode.OK),
                () => response.Content.Should().ContainAll(new string[] {
                        "\"name\":\"morpheus\"",
                        "\"job\":\"zion resident\"",
                        "updatedAt"}));
        }
}
}
