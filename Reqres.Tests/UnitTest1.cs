using Reqres.Core;
using RestSharp;
using System.Text.Unicode;
using System.Text;

namespace Reqres.Tests
{
    public class UnitTest1 : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public UnitTest1(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            builder.Headers.Add("Accept", "text/html");
            Client client = builder.GetClient();
            var answer = client.Post("api/users?page=2", "{\"name\": \"morpheus\", \"job\": \"leader\"}");
        }

        [Fact]
        public void Test2()
        {

        }
    }
}