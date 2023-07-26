using OpenQA.Selenium;
using Costco.Core.Elements;
using Costco.Web.Blocks;

namespace Costco.Web.Pages
{
    public class LocationsPage: BasePage
    {
        public override string Url => "https://www.costco.com/warehouse-locations";
        public readonly By warehouseSearchLocator = By.Id("search-warehouse");
        public readonly By findButtonLocator = By.XPath("//button[@automation-id='findButton']");
        public readonly By setAsMyWarehouseButtonLocator = By.XPath("//input[@aria-describedby='setMyWarehouseLocation1']");
        public readonly By storeDetailsButtonLocator = By.XPath("//a[@automation-id='storeDetailsLink_1']");
        public readonly By warehouseNameLocator = By.XPath("//a[@automation-id='warehouseNames_1']");
        public readonly By warehouseAddressLocator = By.XPath("//span[@automation-id='warehouseAddressLine1Output_1']");

        public InputField WarehouseSearch => new(warehouseSearchLocator);
        public Button FindButton => new(findButtonLocator);
        public Button SetAsMyWarehouseButton => new(setAsMyWarehouseButtonLocator);
        public Button StoreDetailsButton => new(storeDetailsButtonLocator);
        public TextBox WarehouseName => new(warehouseNameLocator);
        public TextBox WarehouseAddress => new(warehouseAddressLocator);
        public LocationsBlock LocationsBlock => new LocationsBlock();

        public void SearchForWarehouse(string input)
        {
            WarehouseSearch.Clear();
            WarehouseSearch.SendKeys(input);
            FindButton.Click();
        }

        public void SetAsMyWarehouse()
        {
            SetAsMyWarehouseButton.Click();
        }

        public void ClickStoreDetails()
        {
            StoreDetailsButton.Click();
        }

        public string GetWarehouseName()
        {
            return WarehouseName.Text;
        }
        
        public string GetWarehouseAddress()
        {
            return WarehouseAddress.Text;
        }

        public bool IsWarehouseSet(string warehouse)
        {
            return LocationsBlock.IsWarehouseSet(warehouse);
        }

        public bool IsDeliveryLocationSet(string location)
        {
            return LocationsBlock.IsDeliveryLocationSet(location);
        }

        public bool IsResultFound(string result)
        {
            return WarehouseName.Text.Equals(result);
        }
    }
}