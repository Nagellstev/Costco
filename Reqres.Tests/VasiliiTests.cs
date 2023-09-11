using Reqres.Core;
using RestSharp;
using System.Text.Unicode;
using System.Text;
using FluentAssertions;
using System.Net;
using Costco.Utilities.FileReader;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class VasiliiTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public VasiliiTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void RegisterWithEmailAndPassword()
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
        public void FailToRegisterWithEmail()
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

        [Fact]
        public void LoginWithEmailAndPassword()
        {
            Client client = builder.GetClient();
            string url = "api/login";
            string body =
                "{" +
                    "\"email\": \"eve.holt@reqres.in\", " +
                    "\"password\": \"cityslicka\"" +
                "}";
            var response = client.Post(url, body);

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Should().Contain("token");
            }
        }
    }
}
