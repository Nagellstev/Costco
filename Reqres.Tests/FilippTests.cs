using Reqres.Core;
using FluentAssertions;
using System.Net;
using Costco.Utilities.StringExtension;

namespace Reqres.Tests
{
    public class FilippTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public FilippTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateAUserWithNewCredentials()
        {
            Client client = builder.GetClient();

            var response = client.Post(
                "api/users",
                "{" +
                    "\"name\": \"morpheus\", " +
                    "\"job\": \"leader\"" +
                "}");
            Assert.Multiple(
                () => response.StatusCode.Should().Be(HttpStatusCode.Created),
                () => response.Content.Should().ContainAll(new string[] {
                        "\"name\":\"morpheus\"",
                        "\"job\":\"leader\"",
                        "id",
                        "createdAt"}));
        }

        [Fact]
        public void CreateAUserWithEmptyRequestBody()
        {
            Client client = builder.GetClient();
            var response = client.Post(
                "api/users",
                "{ }");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CreatedUsersAppearInTheDatabase()
        {
            Client client = builder.GetClient();
            string lowCutoff = "\"id\":\"";
            string highCutoff = "\",\"createdAt\"";

            var response = client.Post(
                "api/users",
                "{" +
                    "\"name\": \"morpheus\", " +
                    "\"job\": \"leader\"" +
                "}");      
            string id = response.Content;

            id = id.Substring(lowCutoff, highCutoff);
            response = client.Get($"https://reqres.in/api/users/{id}");

            Assert.Multiple(
                () => response.StatusCode.Should().Be(HttpStatusCode.OK),
                () => response.Content.Should().ContainAll(new string[] {
                        "\"name\":\"morpheus\"",
                        "\"job\":\"leader\"",
                        "id"}));
        }
    }
}