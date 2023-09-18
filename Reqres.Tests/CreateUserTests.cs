using Reqres.Core;
using FluentAssertions;
using System.Net;
using Costco.Utilities.Extensions;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class CreateUserTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public CreateUserTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateAUserWithNewCredentialsTest()
        {
            Client client = builder.GetClient();

            var response = client.Post(
                "api/users",
                "{" +
                    "\"name\": \"morpheus\", " +
                    "\"job\": \"leader\"" +
                "}");

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.Created);
                response.Content.Should().ContainAll(new string[] {
                        "\"name\":\"morpheus\"",
                        "\"job\":\"leader\"",
                        "id",
                        "createdAt"});
            }
        }

        [Fact]
        public void CreateAUserWithEmptyRequestBodyTest()
        {
            Client client = builder.GetClient();
            var response = client.Post(
                "api/users",
                "{ }");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CreatedUsersAppearInTheDatabaseTest()
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

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Should().ContainAll(new string[] {
                        "\"name\":\"morpheus\"",
                        "\"job\":\"leader\"",
                        "id"});
            }
        }
    }
}