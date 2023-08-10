using Costco.Core.Browser;
using Costco.TestData.Models;
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

        [Theory]
        [ClassTestData("ProductPageTestData.json", typeof(ProductPageDataModel))]
        public void AddToCartZeroItemsTest(ProductPageDataModel model)
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartZeroItemsTest);
            steps.InputProductAmount(int.Parse(model.ZeroItemsInput));
            steps.PressAddToCart();

            Assert.Contains(model.ZeroItemsError, steps.GetErrorText());
        }

        [Theory]
        [ClassTestData("ProductPageTestData.json", typeof(ProductPageDataModel))]
        public void AddToCartMoreLimitedItemsThanAllowedTest(ProductPageDataModel model)
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartMoreLimitedItemsThanAllowedTest);
            int amount = steps.GetMaximumLimitedItemsAllowed(model.LowCutoffString, model.HighCutoffString);
            steps.InputProductAmount(amount + 1);
            steps.PressAddToCart();
            steps.PressAddToCart();

            Assert.Contains(String.Format(model.MemberItemsError, steps.GetItemNumber(), amount), steps.GetErrorText());
        }

        [Theory]
        [ClassTestData("ProductPageTestData.json", typeof(ProductPageDataModel))]
        public void ExceedMaximumAmountOfItemsInCartInputFieldTest(ProductPageDataModel model)
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.ExceedMaximumAmountOfItemsInCartInputFieldTest);
            steps.InputProductAmount(int.Parse(model.OverMaxItemsInput));
            steps.PressPlusOneStepper(int.Parse(model.OverMaxItemsStepper));
            steps.PressAddToCart();

            Assert.Equal(model.OverMaxItemsError, steps.GetInputFieldErrorText());
        }
    }
}