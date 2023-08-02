using Costco.Core.Browser;
using Costco.Web.Pages;
using Costco.Web.Steps;

namespace Costco.Tests
{
    [Trait("Target", "ProductPage")]
    public class ProductPageTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        ProductPageSteps steps;

        public ProductPageTests(TestFixture fixture, ITestOutputHelper output): base(output)
        {
            this.fixture = fixture;
            steps = new(new());
        }

        [Fact]
        public void AddToCartZeroItemsTest()
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartZeroItemsTest);
            steps.InputProductAmount(0);
            steps.PressAddToCart();

            Assert.Contains("Quantity must be 1 or more to add to cart.", steps.GetErrorText());
        }

        [Fact]
        public void AddToCartMoreLimitedItemsThanAllowedTest()
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartMoreLimitedItemsThanAllowedTest);
            int amount = steps.GetMaximumLimitedItemsAllowed("Limit ", " per member");
            steps.InputProductAmount(amount + 1);
            steps.PressAddToCart();
            steps.PressAddToCart();

            Assert.Contains($"Item {steps.GetItemNumber()} has a maximum order quantity of {amount}", 
                steps.GetErrorText());
        }

        [Fact]
        public void ExceedMaximumAmountOfItemsInCartInputFieldTest()
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.ExceedMaximumAmountOfItemsInCartInputFieldTest);
            steps.InputProductAmount(999);
            steps.PressPlusOneStepper(1);
            steps.PressAddToCart();

            Assert.Equal("Please enter no more than 3 characters.", steps.GetInputFieldErrorText());
        }
    }
}