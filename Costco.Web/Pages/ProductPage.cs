using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class ProductPage: BasePage
    {
        private string url;
        public override string Url => url;

        public ProductPage(string url)
        {
             this.url = url;
        }

        public By PromotionalTextPath => By.CssSelector(".marketing-container > p.PromotionalText");
        public By QuantityInputPath => By.CssSelector(".quantity-selector-v2 input");
        public By ErrorMessageBelowInputPath => By.CssSelector(".product-error:not(:empty)");
        public By MinusStepperPath => By.Id("minusQty");
        public By PlusStepperPath => By.Id("plusQty");
        public By AddToCartButtonPath => By.Id("add-to-cart-btn");
        public By ErrorMessageInsideInputPath => By.Id("minQtyText-error");
        public By ItemNumberPath => By.XPath("//*[@automation-id = 'itemNumber']");

        public TextBox PromotionalText => new TextBox(PromotionalTextPath);
        public InputField QuantityInput => new InputField(QuantityInputPath);
        public Button MinusStepper => new Button(MinusStepperPath);
        public Button PlusStepper => new Button(PlusStepperPath);
        public Button AddToCartButton => new Button(AddToCartButtonPath);
        public TextBox ErrorMessageBelowInput => new TextBox(ErrorMessageBelowInputPath);
        public TextBox ErrorMessageInsideInput => new TextBox(ErrorMessageInsideInputPath);
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
