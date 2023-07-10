using OpenQA.Selenium;

namespace Costco.Web
{
    public class ProductPageMap: BasePageMap
    {
        public By PromotionalText => By.XPath("//*[@class = 'PromotionalText']");
        public By QuantityInput => By.XPath("//input[@automation-id='quantityInput']");
        public By MinusStepper => By.XPath("//button[@id = 'minusQty']");
        public By PlusStepper => By.XPath("//button[@id = 'plusQty']");
        public By AddToCartButton => By.XPath("//input[@automation-id='addToCartButton']");
        public By ProductError => By.XPath("//div[@id = 'product-error']");
        public By InputError => By.XPath("//label[@id = 'minQtyText-error']");
    }
}
