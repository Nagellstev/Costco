using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class ProductPage: BasePage
    {
        public By PromotionalTextPath => By.CssSelector(".marketing-container > p.PromotionalText");
        public By QuantityInputPath => By.CssSelector(".quantity-selector-v2 input");
        public By ProductErrorPath => By.CssSelector(".product-error");
        public By MinusStepperPath => By.Id("minusQty");
        public By PlusStepperPath => By.Id("plusQty");
        public By AddToCartButtonPath => By.Id("add-to-cart-btn");
        public By InputErrorPath => By.Id("minQtyText-error");

        public TextBox PromotionalText => new TextBox(PromotionalTextPath);
        public InputField QuantityInput => new InputField(QuantityInputPath);
        public Button MinusStepper => new Button(MinusStepperPath);
        public Button PlusStepper => new Button(PlusStepperPath);
        public Button AddToCartButton => new Button(AddToCartButtonPath);
        public TextBox ProductError => new TextBox(ProductErrorPath);
        public TextBox InputError => new TextBox(InputErrorPath);
    }
}
