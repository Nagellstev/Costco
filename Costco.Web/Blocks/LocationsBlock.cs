using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Blocks
{
    public class LocationsBlock : BaseBlock
    {
        private static readonly By locationsBlockLocator = By.Id("deliveryLocation");

        public readonly By myWarehouseLocator = By.XPath("//button[contains(@aria-label, 'current warehouse')]");
        public readonly By deliveryLocationLocator = By.XPath("//button[contains(@aria-label, 'ZIP Code')]");
        public readonly By zipCodeInputLocator = By.Id("zipCode");
        public readonly By changeDeliveryLocationButtonLocator = By.XPath("//button[text()='Change Delivery Location']");

        public LocationsBlock() : base(locationsBlockLocator) { }

        public Button MyWarehouseButton => new(myWarehouseLocator);
        public Button DeliveryLocationButton => new(deliveryLocationLocator);
        public InputField ZipCodeInput => new(zipCodeInputLocator);
        public Button ChangeDeliveryLocationButton => new(changeDeliveryLocationButtonLocator);

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