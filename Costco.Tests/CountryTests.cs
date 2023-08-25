using Costco.TestData.Models;
using Costco.Web.Steps;
using Costco.Web.Pages;

namespace Costco.Tests
{
    [Trait("Target", "Login")]
    public class CountryTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        private MainPage mainPage;

        public CountryTests(TestFixture fixture, ITestOutputHelper output) : base(output)
        {
            this.fixture = fixture;
            mainPage = new();
        }

        [Fact]
        public void SelectCanadaAndFrench()
        {
            mainPage.CountrySelectButton.Hover();
            mainPage.CountrySelectList.ClickElementByText("Canada");
        }
    }
}
