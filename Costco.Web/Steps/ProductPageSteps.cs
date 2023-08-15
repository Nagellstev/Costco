using Costco.Core.Browser;
using Costco.Utilities.Logger;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class ProductPageSteps
    {
        private ProductPage _productPage;

        public ProductPageSteps(ProductPage productPage)
        {
            _productPage = productPage;
        }

        public void InputProductAmount(int amount)
        {
            Waiters.WaitForCondition(_productPage.QuantityInput.IsDisplayed);
            _productPage.QuantityInput.Clear();
            Logger.Information($"Inputting {amount} in product order quantity field.");
            _productPage.QuantityInput.SendKeys(amount.ToString());
        }

        public void PressAddToCart()
        {
            Logger.Information($"Pressing \"Add to card\" button.");
            _productPage.AddToCartButton.Click();
        }

        public void PressPlusOneStepper(int quantity)
        {
            Logger.Information($"Pressing + stepper {quantity} times.");
            for (int i = 0; i < quantity; i++)
            {
                Waiters.WaitForCondition(_productPage.PlusStepper.IsEnabled);
                _productPage.PlusStepper.Click();
            }
        }

        public int GetMaximumLimitedItemsAllowed(string lowCutoff, string highCutoff)
        {
            Waiters.WaitForCondition(_productPage.PromotionalText.IsDisplayed);
            string promoTextMaxQuantity = _productPage.PromotionalText.Text;
            promoTextMaxQuantity = promoTextMaxQuantity.Substring(
                promoTextMaxQuantity.IndexOf(lowCutoff) + lowCutoff.Length,
                promoTextMaxQuantity.IndexOf(highCutoff) - promoTextMaxQuantity.IndexOf(lowCutoff) - lowCutoff.Length);
            Logger.Information($"Maximum number of items allowed is determined to be {promoTextMaxQuantity}.");
            return Int32.Parse(promoTextMaxQuantity);
        }

        public string GetErrorText()
        {
            Waiters.WaitUntilElementExists(_productPage.ErrorMessageBelowInputPath);
            Logger.Information($"Received error \"{_productPage.ErrorMessageBelowInput.Text.Trim()}\".");
            return _productPage.ErrorMessageBelowInput.Text.Trim();
        }

        public string GetInputFieldErrorText()
        {
            Waiters.WaitForCondition(_productPage.ErrorMessageInsideInput.IsDisplayed);
            Logger.Information($"Received error \"{_productPage.ErrorMessageInsideInput.Text.Trim()}\".");
            return _productPage.ErrorMessageInsideInput.Text.Trim();
        }

        public string GetItemNumber()
        {
            return _productPage.ItemNumber.Text;
        }
    }
}
