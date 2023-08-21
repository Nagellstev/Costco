using Costco.Web.Pages;
using Costco.Core.Browser;
using Costco.Utilities.Screenshoter;
using Costco.Utilities.Logger;
using TechTalk.SpecFlow;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class ProductPageStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private ProductPage _productPage;
        string promoTextMaxQuantity;

        public ProductPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Logger.Information($"Initializing {_scenarioContext.ScenarioInfo.Title}.");
            _productPage = new();
            BrowserFactory.Browser.Maximize();
        }

        [BeforeFeature]
        public static void Setup()
        {
            Logger.Init("Costco", TestSettings.LoggerPath);
            Screenshoter.Init(TestSettings.ScreenshotPath);
            Logger.Information("Setup complete.");
        }

        [AfterScenario]
        public void Cleanup()
        {
            if (_scenarioContext.TestError != null)
            {
                Logger.Error($"Test '{_scenarioContext.ScenarioInfo.Title}' failed, {_scenarioContext.TestError.Message}\nException: {_scenarioContext.TestError.InnerException}");
                Screenshoter.TakeScreenshot(Browser.Driver, _scenarioContext.ScenarioInfo.Title);
            }

            BrowserFactory.CleanUp();
            Logger.Information($"Disposing of {_scenarioContext.ScenarioInfo.Title}.");
        }

        [Given(@"I opened the product page (.*)")]
        public void OpenPage(string url)
        {
            BrowserFactory.Browser.GoToUrl(url);
        }

        [Given("I want to order (.*) items")]
        public void InputDesiredQuantity(int quantity)
        {
            _scenarioContext["OrderQuantity"] = quantity;
        }

        [Given("I see the maximum number of limited items I can order")]
        public void GetMaximumLimitedItemsAllowed()
        {
            string lowCutoff = "Limit ";
            string highCutoff = " per member";

            Waiters.WaitForCondition(_productPage.PromotionalText.IsDisplayed);
            promoTextMaxQuantity = _productPage.PromotionalText.Text;
            promoTextMaxQuantity = promoTextMaxQuantity.Substring(
                promoTextMaxQuantity.IndexOf(lowCutoff) + lowCutoff.Length,
                promoTextMaxQuantity.IndexOf(highCutoff) - promoTextMaxQuantity.IndexOf(lowCutoff) - lowCutoff.Length);
            _scenarioContext["OrderQuantity"] = promoTextMaxQuantity;
        }

        [When(@"I add (.*) more to the desired amount")]
        public void InputZeroProductAmount(int amount)
        {
            _scenarioContext["OrderQuantity"] = Int32.Parse((string)_scenarioContext["OrderQuantity"]) + amount;
        }

        [When(@"I enter the desired amount to the product amount field")]
        public void InputZeroProductAmount()
        {
            Waiters.WaitForCondition(_productPage.QuantityInput.IsDisplayed);
            _productPage.QuantityInput.Clear();
            _productPage.QuantityInput.SendKeys(_scenarioContext["OrderQuantity"].ToString());
        }

        [When("I press add to card button")]
        public void PressAddToCart()
        {
            _productPage.AddToCartButton.Click();
        }

        [When("I press plus stepper")]
        public void PressPlusOneStepper()
        {
            Waiters.WaitForCondition(_productPage.PlusStepper.IsEnabled);
            _productPage.PlusStepper.Click();
        }

        [Then("Error (.*) is displayed below the input field")]
        public void GetBelowFieldErrorText(string error)
        {
            Waiters.WaitUntilElementExists(_productPage.ErrorMessageBelowInputPath);
            switch (error)
            {
                case "Item ... has a maximum order quantity of ...":
                    {
                        Assert.Contains($"Item {_productPage.ItemNumber.Text} has a maximum order quantity of {promoTextMaxQuantity}",
                            _productPage.ErrorMessageBelowInput.Text.Trim());
                        break;
                    }

                default:
                    {
                        Assert.Contains(error, _productPage.ErrorMessageBelowInput.Text.Trim());
                        break;
                    }
            }
        }

        [Then("Error (.*) is displayed in the input field")]
        public void GetInputFieldErrorText(string error)
        {
            Waiters.WaitForCondition(_productPage.ErrorMessageInsideInput.IsDisplayed);
            Assert.Contains(error, _productPage.ErrorMessageInsideInput.Text.Trim());
        }
    }
}
