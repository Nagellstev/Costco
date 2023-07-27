using Costco.Core.Browser;
using Costco.Web.Pages;

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
        public void AddToCartZeroItemsTest()
        {
            ProductPage productPage = new();

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartZeroItemsTest);
            Waiters.WaitForCondition(productPage.QuantityInput.IsDisplayed, 30);
            productPage.InputProductAmount("0");
            productPage.AddToCartButton.Click();
            Waiters.WaitUntilElementExists(productPage.ErrorMessageBelowInputPath, 30);

            Assert.Contains("Quantity must be 1 or more to add to cart.", productPage.GetErrorText());
        }

        [Fact]
        public void AddToCartMoreLimitedItemsThanAllowedTest()
        {
            ProductPage productPage = new();
            string lowCutoff = "Limit ";
            string highCutoff = " per member";

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartMoreLimitedItemsThanAllowedTest);
            Waiters.WaitForCondition(productPage.PromotionalText.IsDisplayed, 30);
            string promoTextMaxQuantity = productPage.PromotionalText.Text;
            promoTextMaxQuantity = promoTextMaxQuantity.Substring(
                promoTextMaxQuantity.IndexOf(lowCutoff) + lowCutoff.Length,
                promoTextMaxQuantity.IndexOf(highCutoff) - promoTextMaxQuantity.IndexOf(lowCutoff) - lowCutoff.Length);
            Waiters.WaitForCondition(productPage.QuantityInput.IsDisplayed, 30);
            productPage.InputProductAmount((Int32.Parse(promoTextMaxQuantity) + 1).ToString());
            productPage.AddToCartButton.Click();
            productPage.AddToCartButton.Click();
            Waiters.WaitUntilElementExists(productPage.ErrorMessageBelowInputPath, 30);

            Assert.Contains($"Item {productPage.ItemNumber.Text} has a maximum order quantity of {promoTextMaxQuantity}", 
                productPage.GetErrorText());
        }

        [Fact]
        public void ExceedMaximumAmountOfItemsInCartInputFieldTest()
        {
            ProductPage productPage = new();

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.ExceedMaximumAmountOfItemsInCartInputFieldTest);
            Waiters.WaitForCondition(productPage.QuantityInput.IsDisplayed, 30);
            productPage.InputProductAmount("999");
            productPage.PlusStepper.Click();
            productPage.AddToCartButton.Click();
            Waiters.WaitForCondition(productPage.ErrorMessageInsideInput.IsDisplayed, 30);

            Assert.Equal("Please enter no more than 3 characters.", productPage.GetInputFieldErrorText());
        }
    }
}