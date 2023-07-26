using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Web.Pages;
using Costco.Web.Steps;

namespace Costco.Tests
{
    [Trait("Target", "ProductPage")]
    public class CostcoProductPageTestSuite : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public CostcoProductPageTestSuite(TestFixture fixture, ITestOutputHelper output): base(output)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ZeroProductsReturnError()
        {
            ProductPageSteps steps = new(new());

            BrowserFactory.Browser.GoToUrl(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[0]);
            steps.AddToCart("0");

            Assert.Contains("Quantity must be 1 or more to add to cart.", steps.GetErrorText());
        }

        [Fact]
        public void OverLimitProductsReturnError()
        {
            ProductPageSteps steps = new(new());

            BrowserFactory.Browser.GoToUrl(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[1]);
            int amount = steps.GetMaximumLimitedItemsAllowed();
            steps.AddToCart((amount + 1).ToString());

            Assert.Contains($"Item {steps.GetItemNumber()} has a maximum order quantity of {amount}", 
                steps.GetErrorText());
        }

        [Fact]
        public void OverMaximumProductReturnError()
        {
            ProductPageSteps steps = new(new());

            BrowserFactory.Browser.GoToUrl(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[2]);
            steps.AddToCartPlusOne("999");

            Assert.Equal("Please enter no more than 3 characters.", steps.GetInputFieldErrorText());
        }
    }
}