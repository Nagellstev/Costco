using Costco.Core.Browser;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class LocationsPageSteps
    {
        private LocationsPage locationsPage;

        public LocationsPageSteps(LocationsPage locationsPage)
        {
            this.locationsPage = locationsPage;
        }

        public void SearchForWarehouse(string input)
        {
            Waiters.WaitForCondition(() => locationsPage.WarehouseSearch.IsEnabled());
            locationsPage.WarehouseSearch.Clear();
            locationsPage.WarehouseSearch.SendKeys(input);
            locationsPage.FindButton.Click();
            Waiters.WaitForCondition(() => IsResultFound(input));
        }

        public void SetAsMyWarehouse(string warehouse)
        {
            Waiters.WaitForCondition(() => locationsPage.SetAsMyWarehouseButton.IsEnabled());
            locationsPage.SetAsMyWarehouseButton.Click();
            Waiters.WaitForCondition(() => IsWarehouseSet(warehouse));
        }

        public void ClickStoreDetails()
        {
            locationsPage.StoreDetailsButton.Click();
        }

        public string GetWarehouseName()
        {
            return locationsPage.WarehouseName.Text;
        }

        public string GetWarehouseAddress()
        {
            return locationsPage.WarehouseAddress.Text;
        }

        public bool IsWarehouseSet(string warehouse)
        {
            return locationsPage.LocationsBlock.MyWarehouseButton.Text.Equals(warehouse);
        }

        public bool IsDeliveryLocationSet(string location)
        {
            return locationsPage.LocationsBlock.DeliveryLocationButton.Text.Equals(location);
        }

        public bool IsResultFound(string result)
        {
            return locationsPage.WarehouseName.Text.Equals(result);
        }

        public void SetDeliveryLocation(string deliveryLocation)
        {
            locationsPage.LocationsBlock.DeliveryLocationButton.Click();
            locationsPage.LocationsBlock.ZipCodeInput.Clear();
            locationsPage.LocationsBlock.ZipCodeInput.SendKeys(deliveryLocation);
            locationsPage.LocationsBlock.ChangeDeliveryLocationButton.Click();
            Waiters.WaitForCondition(() => IsDeliveryLocationSet(deliveryLocation));
        }
    }
}
