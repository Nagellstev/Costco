using Costco.Core.Browser;
using Costco.Web.Pages;
using Costco.Utilities.StringExtension;

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
            _productPage.QuantityInput.Clear();
            _productPage.QuantityInput.SendKeys(amount.ToString());
        }

        public void PressAddToCart()
        {
            _productPage.AddToCartButton.Click();
        }

        public void PressPlusOneStepper(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                _productPage.PlusStepper.Click();
            }
        }

        public int GetMaximumLimitedItemsAllowed(string lowCutoff, string highCutoff)
        {
            string promoTextMaxQuantity = _productPage.PromotionalText.Text;
            promoTextMaxQuantity = promoTextMaxQuantity.Substring(lowCutoff, highCutoff);
            return Int32.Parse(promoTextMaxQuantity);
        }

        public string GetErrorText()
        {
            return _productPage.ErrorMessageBelowInput.Text.Trim();
        }

        public string GetInputFieldErrorText()
        {
            return _productPage.ErrorMessageInsideInput.Text.Trim();
        }

        public string GetItemNumber()
        {
            return _productPage.ItemNumber.Text;
        }
    }
}
