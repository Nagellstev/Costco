using OpenQA.Selenium;
using Costco.Web.Elements;

namespace Costco.Web.Blocks
{
    public class LocationsBlock : BaseBlock
    {
        private static readonly By locationsBlockLocator = By.Id("deliveryLocation");

        public By MyWarehouseLocator = By.XPath("//button[contains(@aria-label, 'current warehouse')]");
        public By DeliveryLocationLocator = By.XPath("//button[contains(@aria-label, 'ZIP Code')]");
        public By ZipCodeInputLocator = By.Id("//input[@id='zipCode']");
        public By ChangeDeliveryLocationButtonLocator = By.XPath("//button[text()='Change Delivery Location']");

        public Button MyWarehouseButton => new(MyWarehouseLocator);
        public Button DeliveryLocationButton => new(DeliveryLocationLocator);
        public InputField ZipCodeInput => new(ZipCodeInputLocator);
        public Button ChangeDeliveryLocationButton => new(ChangeDeliveryLocationButtonLocator);

        public LocationsBlock() : base(locationsBlockLocator) { }
    }
}