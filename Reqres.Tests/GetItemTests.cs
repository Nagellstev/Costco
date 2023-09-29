using Reqres.Core;
using FluentAssertions;
using System.Net;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class GetItemTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public GetItemTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetNonExistentUserTest()
        {
            //Arrange
            Client client = builder.GetClient();
            string url = "api/users/23";

            //Action
            var response = client.Get(url);

            //Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                response.Content.Should().Be("{}");
            }
        }

        [Fact]
        public void GetNonExistentResourceTest()
        {
            //Arrange
            Client client = builder.GetClient();
            string url = "api/unknown/23";

            //Action
            var response = client.Get(url);

            //Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                response.Content.Should().Be("{}");
            }
        }
    }
}
