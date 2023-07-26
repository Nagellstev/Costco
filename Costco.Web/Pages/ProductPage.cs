using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class ProductPage: BasePage
    {
        public readonly By promotionalTextPath = By.CssSelector(".marketing-container > p.PromotionalText");
        public readonly By quantityInputPath = By.CssSelector(".quantity-selector-v2 input");
        public readonly By errorMessageBelowInputPath = By.CssSelector(".product-error:not(:empty)");
        public readonly By minusStepperPath = By.Id("minusQty");
        public readonly By plusStepperPath = By.Id("plusQty");
        public readonly By addToCartButtonPath = By.Id("add-to-cart-btn");
        public readonly By errorMessageInsideInputPath = By.Id("minQtyText-error");
        public readonly By ItemNumberPath = By.XPath("//*[@automation-id = 'itemNumber']");

        public TextBox PromotionalText => new TextBox(promotionalTextPath);
        public InputField QuantityInput => new InputField(quantityInputPath);
        public TextBox ErrorMessageBelowInput => new TextBox(errorMessageBelowInputPath);
        public Button MinusStepper => new Button(minusStepperPath);
        public Button PlusStepper => new Button(plusStepperPath);
        public Button AddToCartButton => new Button(addToCartButtonPath);
        public TextBox ErrorMessageInsideInput => new TextBox(errorMessageInsideInputPath);
        public TextBox ItemNumber => new TextBox(ItemNumberPath);

        public void InputProductAmount(string amount)
        {
            QuantityInput.Clear();
            QuantityInput.SendKeys(amount);
        }

        public string GetErrorText()
        {
            return ErrorMessageBelowInput.Text.Trim();
        }

        public string GetInputFieldErrorText()
        {
            return ErrorMessageInsideInput.Text.Trim();
        }
    }
}
