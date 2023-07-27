using OpenQA.Selenium;
using Costco.Core.Elements;
using Costco.Web.Blocks;

namespace Costco.Web.Pages
{
    public class LocationsPage: BasePage
    {
        public override string Url => "https://www.costco.com/warehouse-locations";
        public readonly By WarehouseSearchLocator = By.Id("search-warehouse");
        public readonly By FindButtonLocator = By.XPath("//button[@automation-id='findButton']");
        public readonly By SetAsMyWarehouseButtonLocator = By.XPath("//input[@aria-describedby='setMyWarehouseLocation1']");
        public readonly By StoreDetailsButtonLocator = By.XPath("//a[@automation-id='storeDetailsLink_1']");
        public readonly By WarehouseNameLocator = By.XPath("//a[@automation-id='warehouseNames_1']");
        public readonly By WarehouseAddressLocator = By.XPath("//span[@automation-id='warehouseAddressLine1Output_1']");

        public InputField WarehouseSearch => new(WarehouseSearchLocator);
        public Button FindButton => new(FindButtonLocator);
        public Button SetAsMyWarehouseButton => new(SetAsMyWarehouseButtonLocator);
        public Button StoreDetailsButton => new(StoreDetailsButtonLocator);
        public TextBox WarehouseName => new(WarehouseNameLocator);
        public TextBox WarehouseAddress => new(WarehouseAddressLocator);
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