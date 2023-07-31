using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class ProductPage: BasePage
    {
        public readonly By PromotionalTextPath = By.CssSelector(".marketing-container > p.PromotionalText");
        public readonly By QuantityInputPath = By.CssSelector(".quantity-selector-v2 input");
        public readonly By ErrorMessageBelowInputPath = By.CssSelector(".product-error:not(:empty)");
        public readonly By MinusStepperPath = By.Id("minusQty");
        public readonly By PlusStepperPath = By.Id("plusQty");
        public readonly By AddToCartButtonPath = By.Id("add-to-cart-btn");
        public readonly By ErrorMessageInsideInputPath = By.Id("minQtyText-error");
        public readonly By ItemNumberPath = By.XPath("//*[@automation-id = 'itemNumber']");

        public TextBox PromotionalText => new TextBox(PromotionalTextPath);
        public InputField QuantityInput => new InputField(QuantityInputPath);
        public TextBox ErrorMessageBelowInput => new TextBox(ErrorMessageBelowInputPath);
        public Button MinusStepper => new Button(MinusStepperPath);
        public Button PlusStepper => new Button(PlusStepperPath);
        public Button AddToCartButton => new Button(AddToCartButtonPath);
        public TextBox ErrorMessageInsideInput => new TextBox(ErrorMessageInsideInputPath);
        public TextBox ItemNumber => new TextBox(ItemNumberPath);
    }
}
