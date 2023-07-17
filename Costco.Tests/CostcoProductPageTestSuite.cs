using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;
using Costco.Web.Pages;
using OpenQA.Selenium.Support.UI;

namespace Costco.Tests
{
    public class CostcoProductPageTestSuite : IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public CostcoProductPageTestSuite(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ZeroProductsReturnError()
        {
            try 
            {
                ProductPage productPage = new(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[0]);

                BrowserFactory.Browser.GoToUrl(productPage.Url);
                Waiters.WaitForCondition(productPage.QuantityInput.IsDisplayed, 30);
                productPage.InputProductAmount("0");
                productPage.AddToCartButton.Click();
                Waiters.WaitForCondition(productPage.ErrorMessageBelowInput.IsDisplayed, 30);

                Assert.Contains("Quantity must be 1 or more to add to cart.", productPage.GetErrorText());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver); 
                throw;
            }
        }

        [Fact]
        public void OverLimitProductsReturnError()
        {
            try
            {
                ProductPage productPage = new(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[1]);
                string lowCutoff = "Limit ";
                string highCutoff = " per member";

                BrowserFactory.Browser.GoToUrl(productPage.Url);
                Waiters.WaitForCondition(productPage.PromotionalText.IsDisplayed, 30);
                string promoTextMaxQuantity = productPage.PromotionalText.Text;

                promoTextMaxQuantity = promoTextMaxQuantity.Substring(
                    promoTextMaxQuantity.IndexOf(lowCutoff) + lowCutoff.Length,
                    promoTextMaxQuantity.IndexOf(highCutoff) - promoTextMaxQuantity.IndexOf(lowCutoff) - lowCutoff.Length);

                Waiters.WaitForCondition(productPage.QuantityInput.IsDisplayed, 30);

                productPage.InputProductAmount((Int32.Parse(promoTextMaxQuantity) + 1).ToString());

                productPage.AddToCartButton.Click();
                Waiters.WaitForCondition(productPage.ErrorMessageBelowInput.IsEnabled, 30);

                Assert.Contains($"Item {productPage.ItemNumber} has a maximum order quantity of {promoTextMaxQuantity}", 
                    productPage.GetErrorText());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }

        [Fact]
        public void OverMaximumProductReturnError()
        {
            try
            {
                ProductPage productPage = new(((ProductPageTestDataModel)fixture.testData).ProductPageUrl[2]);

                BrowserFactory.Browser.GoToUrl(productPage.Url);
                Waiters.WaitForCondition(productPage.QuantityInput.IsDisplayed, 30);
                productPage.InputProductAmount("999");
                productPage.PlusStepper.Click();
                productPage.AddToCartButton.Click();
                Waiters.WaitForCondition(productPage.ErrorMessageInsideInput.IsDisplayed, 30);

                Assert.Equal("Please enter no more than 3 characters.", productPage.GetInputFieldErrorText());
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshotter.TakeScreenshot(Browser.Driver);
                throw;
            }
        }
    }
}