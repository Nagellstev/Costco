using Reqres.Core;
using FluentAssertions;
using System.Net;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class RegistrationTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public RegistrationTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void RegisterWithEmailAndPasswordTest()
        {
            Client client = builder.GetClient();
            string url = "api/register";
            string body =
                "{" +
                    "\"email\": \"eve.holt@reqres.in\", " +
                    "\"password\": \"pistol\"" +
                "}";
            var response = client.Post(url, body);

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Should().ContainAll(new string[] {
                    "id",
                    "token"});
            }
        }

        [Fact]
        public void FailToRegisterWithEmailTest()
        {
            Client client = builder.GetClient();
            string url = "api/register";
            string body =
                "{" +
                    "\"email\":\"sydney@fife\"" +
                "}";
            var response = client.Post(url, body);

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                response.Content.Should().Contain("\"error\":\"Missing password\"");
            }
        }
    }
}
