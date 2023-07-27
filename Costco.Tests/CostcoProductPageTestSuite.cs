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
        ProductPageSteps steps;

        public CostcoProductPageTestSuite(TestFixture fixture, ITestOutputHelper output): base(output)
        {
            this.fixture = fixture;
            steps = new(new());
        }

        [Fact]
        public void ZeroProductsReturnError()
        {
            BrowserFactory.Browser.GoToUrl(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[0]);
            steps.InputProductAmount(0);
            steps.PressAddToCart();

            Assert.Contains("Quantity must be 1 or more to add to cart.", steps.GetErrorText());
        }

        [Fact]
        public void OverLimitProductsReturnError()
        {
            BrowserFactory.Browser.GoToUrl(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[1]);
            int amount = steps.GetMaximumLimitedItemsAllowed();
            steps.InputProductAmount(amount + 1);

            Assert.Contains($"Item {steps.GetItemNumber()} has a maximum order quantity of {amount}", 
                steps.GetErrorText());
        }

        [Fact]
        public void OverMaximumProductReturnError()
        {
            BrowserFactory.Browser.GoToUrl(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[2]);
            steps.InputProductAmount(999);
            steps.PressPlusOneStepper(1);

            Assert.Equal("Please enter no more than 3 characters.", steps.GetInputFieldErrorText());
        }
    }
}