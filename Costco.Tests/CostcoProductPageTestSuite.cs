using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;
using Costco.Web.Pages;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

                WebDriverWait wait = new(Browser.Driver, TimeSpan.FromSeconds(30));


                productPage.InputProductAmount("0");
                productPage.AddToCartButton.Click();

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
                BrowserFactory.Browser.GoToUrl(productPage.Url);
                string promotionalText = productPage.PromotionalText.Text;


                productPage.InputProductAmount("16");
                productPage.AddToCartButton.Click();
                Assert.Contains("", productPage.GetErrorText());

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
                productPage.InputProductAmount("999");
                productPage.PlusStepper.Click();
                productPage.AddToCartButton.Click();
                Assert.Equal("Please enter no more than 3 characters", productPage.GetInputFieldErrorText());

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