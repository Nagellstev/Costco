﻿using Costco.Web.Pages;
using Costco.Core.Browser;
using TechTalk.SpecFlow;

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

        [When(@"I locate the promo text with number of limited items")]
        public void WhenILocateTheMaximumNumberOfLimitedItemsICanOrder()
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
        }

        [When(@"I enter '(.*)' to the product amount field")]
        public void WhenIEnterToTheProductAmountField(int amount)
        {
            Waiters.WaitForCondition(_productPage.QuantityInput.IsDisplayed);
            _productPage.QuantityInput.Clear();
            _productPage.QuantityInput.SendKeys(amount.ToString());
        }

        [When(@"I enter maximum number of limited items plus one to the product amount field")]
        public void WhenIEnterToTheProductAmountFieldMaximumNumberOfLimitedItemsPlusOne()
        {
            Waiters.WaitForCondition(_productPage.QuantityInput.IsDisplayed);
            _productPage.QuantityInput.Clear();
            _productPage.QuantityInput.SendKeys((Convert.ToInt32(_scenarioContext["MaxProductQuantity"]) + 1).ToString());
        }

        [When(@"I press add to cart button")]
        public void WhenIPressAddToCartButton()
        {
            _productPage.AddToCartButton.Click();
        }

        [When(@"I press plus stepper")]
        public void WhenIPressPlusOneStepper()
        {
            Waiters.WaitForCondition(_productPage.PlusStepper.IsEnabled);
            _productPage.PlusStepper.Click();
        }

        [Then(@"Error '(.*)' is displayed below the input field")]
        public void ThenErrorIsDisplayedBelowTheInputField(string error)
        {
            Waiters.WaitUntilElementExists(_productPage.ErrorMessageBelowInputPath);
            _productPage.ErrorMessageBelowInput.Text.Trim().
                Should().
                Contain(error);
        }

        [Then(@"Maximum order quantity error is displayed below the input field")]
        public void ThenMaximumOrderQuantityErrorIsDisplayedBelowTheInputField()
        {
            Waiters.WaitUntilElementExists(_productPage.ErrorMessageBelowInputPath);
            _productPage.ErrorMessageBelowInput.Text.Trim().
                Should().
                ContainAll(new string[] {"Item",
                                        _productPage.ItemNumber.Text,
                                        "has a maximum order quantity of"}).
                And.
                EndWith(_scenarioContext["MaxProductQuantity"].ToString()).
                And.
                MatchRegex("([A-Z][a-z]+ [0-9]+ [a-z ]+ [0-9]+$)");
        }

        [Then(@"Error '(.*)' is displayed in the input field")]
        public void ThenErrorIsDisplayedInTheInputField(string error)
        {
            Waiters.WaitForCondition(_productPage.ErrorMessageInsideInput.IsDisplayed);
            _productPage.ErrorMessageInsideInput.Text.Trim().
                Should().
                Contain(error);
        }
    }
}