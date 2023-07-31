using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Blocks
{
    public class LocationsBlock : BaseBlock
    {
        private static readonly By locationsBlockLocator = By.Id("deliveryLocation");

        private readonly By MyWarehouseLocator = By.XPath("//button[contains(@aria-label, 'current warehouse')]");
        private readonly By DeliveryLocationLocator = By.XPath("//button[contains(@aria-label, 'ZIP Code')]");
        private readonly By ZipCodeInputLocator = By.Id("zipCode");
        private readonly By ChangeDeliveryLocationButtonLocator = By.XPath("//button[text()='Change Delivery Location']");

        public LocationsBlock() : base(locationsBlockLocator) { }

        public Button MyWarehouseButton => new(MyWarehouseLocator);
        public Button DeliveryLocationButton => new(DeliveryLocationLocator);
        public InputField ZipCodeInput => new(ZipCodeInputLocator);
        public Button ChangeDeliveryLocationButton => new(ChangeDeliveryLocationButtonLocator);
    }
}