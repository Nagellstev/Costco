using Costco.Core.Browser;
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
            Waiters.WaitForCondition(_productPage.QuantityInput.IsDisplayed, 30);
            _productPage.QuantityInput.Clear();
            _productPage.QuantityInput.SendKeys(amount.ToString());
        }

        public void PressAddToCart()
        {
            _productPage.AddToCartButton.Click();
        }

        public void PressPlusOneStepper(int times)
        {
            for (int i = 0; i < times; i++, _productPage.PlusStepper.Click());
        }

        public int GetMaximumLimitedItemsAllowed()
        {
            string lowCutoff = "Limit ";
            string highCutoff = " per member";

            Waiters.WaitForCondition(_productPage.PromotionalText.IsDisplayed, 30);
            string promoTextMaxQuantity = _productPage.PromotionalText.Text;
            promoTextMaxQuantity = promoTextMaxQuantity.Substring(
                promoTextMaxQuantity.IndexOf(lowCutoff) + lowCutoff.Length,
                promoTextMaxQuantity.IndexOf(highCutoff) - promoTextMaxQuantity.IndexOf(lowCutoff) - lowCutoff.Length);

            return Int32.Parse(promoTextMaxQuantity);
        }

        public string GetErrorText()
        {
            Waiters.WaitUntilElementExists(_productPage.ErrorMessageBelowInputPath, 30);
            return _productPage.ErrorMessageBelowInput.Text.Trim();
        }

        public string GetInputFieldErrorText()
        {
            Waiters.WaitForCondition(_productPage.ErrorMessageInsideInput.IsDisplayed, 30);
            return _productPage.ErrorMessageInsideInput.Text.Trim();
        }

        public string GetItemNumber()
        {
            return _productPage.ItemNumber.Text;
        }
    }
}
