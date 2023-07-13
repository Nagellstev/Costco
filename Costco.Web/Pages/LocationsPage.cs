using OpenQA.Selenium;
using Costco.Web.Elements;
using Costco.Web.Blocks;

namespace Costco.Web.Pages
{
    public class LocationsPage: BasePage
    {
        public By WarehouseSearchLocator = By.Id("search-warehouse");
        public By FindButtonLocator = By.XPath("//button[@automation-id='findButton']");
        public By SetAsMyWarehouseButtonLocator = By.XPath("//input[@aria-describedby='setMyWarehouseLocation1']");
        public By StoreDetailsButtonLocator = By.XPath("//a[@automation-id='storeDetailsLink_1']");
        public By WarehouseNameLocator = By.XPath("//a[@automation-id='warehouseNames_1']");
        public By WarehouseAddressLocator = By.XPath("//span[@automation-id='warehouseAddressLine1Output_1']");

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
    }
}