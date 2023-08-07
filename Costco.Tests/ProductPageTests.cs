using Costco.Core.Browser;
using Costco.TestData.Models.ProductPage;
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
        [ClassData(typeof(ZeroItemsClassData))]
        public void AddToCartZeroItemsTest(int amount, string expectedResult)
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartZeroItemsTest);
            steps.InputProductAmount(amount);
            steps.PressAddToCart();

            Assert.Contains(expectedResult, steps.GetErrorText());
        }

        [Theory]
        [ClassData(typeof(LimitedMemberItemsClassData))]
        public void AddToCartMoreLimitedItemsThanAllowedTest(string lowCutoff, string highCutoff, string expectedResult)
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.AddToCartMoreLimitedItemsThanAllowedTest);
            int amount = steps.GetMaximumLimitedItemsAllowed(lowCutoff, highCutoff);
            steps.InputProductAmount(amount + 1);
            steps.PressAddToCart();
            steps.PressAddToCart();

            Assert.Contains(String.Format(expectedResult, steps.GetItemNumber(), amount), steps.GetErrorText());
        }

        [Theory]
        [ClassData(typeof(OrderOneThousandClassData))]
        public void ExceedMaximumAmountOfItemsInCartInputFieldTest(int inputAmount, int stepperPressAmount, string expectedResult)
        {
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.ExceedMaximumAmountOfItemsInCartInputFieldTest);
            steps.InputProductAmount(inputAmount);
            steps.PressPlusOneStepper(stepperPressAmount);
            steps.PressAddToCart();

            Assert.Equal(expectedResult, steps.GetInputFieldErrorText());
        }
    }
}