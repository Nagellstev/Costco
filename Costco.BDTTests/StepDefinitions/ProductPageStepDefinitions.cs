using Costco.Web.Pages;
using Costco.Core.Browser;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Security.Policy;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class ProductPageStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private ProductPage _productPage;

        public ProductPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _productPage = new();
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
            string promoTextMaxQuantity;
            Waiters.WaitForCondition(_productPage.PromotionalText.IsDisplayed);
            promoTextMaxQuantity = _productPage.PromotionalText.Text;
            promoTextMaxQuantity = promoTextMaxQuantity.Substring(
                promoTextMaxQuantity.IndexOf(lowCutoff) + lowCutoff.Length,
                promoTextMaxQuantity.IndexOf(highCutoff) - promoTextMaxQuantity.IndexOf(lowCutoff) - lowCutoff.Length);
            _scenarioContext["MaxProductQuantity"] = promoTextMaxQuantity;
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
                        _productPage.ErrorMessageBelowInput.Text.Trim().
                            Should().
                            ContainAll(new string[] {"Item",
                                                    _productPage.ItemNumber.Text,
                                                    "has a maximum order quantity of"}).
                            And.
                            EndWith(_scenarioContext["MaxProductQuantity"].ToString()).
                            And.
                            MatchRegex("([A-Z][a-z]+ [0-9]+ [a-z ]+ [0-9]+$)");
                        break;
                    }
                default:
                    {
                        _productPage.ErrorMessageBelowInput.Text.Trim().
                            Should().
                            Contain(error);
                        break;
                    }
            }
        }

        [Then("Error (.*) is displayed in the input field")]
        public void GetInputFieldErrorText(string error)
        {
            Waiters.WaitForCondition(_productPage.ErrorMessageInsideInput.IsDisplayed);
            _productPage.ErrorMessageInsideInput.Text.Trim().
                Should().
                Contain(error);
        }
    }
}
