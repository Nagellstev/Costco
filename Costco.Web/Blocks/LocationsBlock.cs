using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Blocks
{
    public class LocationsBlock : BaseBlock
    {
        private static readonly By locationsBlockLocator = By.Id("deliveryLocation");

        public By MyWarehouseLocator = By.XPath("//button[contains(@aria-label, 'current warehouse')]");
        public By DeliveryLocationLocator = By.XPath("//button[contains(@aria-label, 'ZIP Code')]");
        public By ZipCodeInputLocator = By.Id("zipCode");
        public By ChangeDeliveryLocationButtonLocator = By.XPath("//button[text()='Change Delivery Location']");

        public LocationsBlock() : base(locationsBlockLocator) { }

        public Button MyWarehouseButton => new(MyWarehouseLocator);
        public Button DeliveryLocationButton => new(DeliveryLocationLocator);
        public InputField ZipCodeInput => new(ZipCodeInputLocator);
        public Button ChangeDeliveryLocationButton => new(ChangeDeliveryLocationButtonLocator);

        public void SetDeliveryLocation(string deliveryLocation)
        {
            DeliveryLocationButton.Click();
            ZipCodeInput.Clear();
            ZipCodeInput.SendKeys(deliveryLocation);
            ChangeDeliveryLocationButton.Click();
        }

        public bool IsWarehouseSet(string warehouse)
        {
            return MyWarehouseButton.Text.Equals(warehouse);
        }

        public bool IsDeliveryLocationSet(string deliveryLocation)
        {
            return DeliveryLocationButton.Text.Equals(deliveryLocation);
        }
    }
}