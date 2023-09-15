using Reqres.Core;
using Reqres.TestData.Models;
using FluentAssertions;
using Costco.TestData.Models;
using FluentAssertions.Execution;

namespace Reqres.Tests
{
    public class GetUserDataTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public GetUserDataTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        /// <summary>
        ///EPMFARMATS-17609 API Reqres delayed request
        ///send get request for list of users with delay parameter
        ///get time, when request was sent
        ///get time, when response was received
        ///Expected result: response time minus request time should be greater than delay parameter
        /// </summary>
        [Theory]
        [ClassTestData("Reqres.TestData\\TestData\\DelayedRequestTestData.json", typeof(DelayedRequestDataModel))]
        public void DelayedRequestTest(DelayedRequestDataModel delayedRequest)
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();

            TimeSpan delay = TimeSpan.FromSeconds(delayedRequest.Delay);

            DateTime requestSentAt = DateTime.Now;

            var answer = client.Get($"/api/users?delay={delay.Seconds}");

            DateTime responseGotAt = DateTime.Now;

            int statusCode = (int)answer.StatusCode;

            using (new AssertionScope())
            {
                statusCode.Should().Be(delayedRequest.ExpectedStatusCode, $"Expected status: '{delayedRequest.ExpectedStatusCode}'.");
                responseGotAt.Subtract(requestSentAt).Should().BeGreaterThanOrEqualTo(delay, $"Expected delay: '{delay}'.");
            }
        }
    }
}