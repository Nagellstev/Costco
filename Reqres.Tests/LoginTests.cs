using Reqres.Core;
using FluentAssertions;
using System.Net;
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

        [Fact]
        public void LoginWithEmailAndPasswordTest()
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
