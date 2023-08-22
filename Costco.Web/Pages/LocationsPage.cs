using OpenQA.Selenium;
using Costco.Core.Elements;
using Costco.Web.Blocks;

namespace Costco.Web.Pages
{
    public class LocationsPage: BasePage
    {
        private readonly By FindButtonLocator = By.XPath("//button[@automation-id='findButton']");
        private readonly By WarehouseSearchLocator = By.Id("search-warehouse");
        private readonly By SetAsMyWarehouseButtonLocator = By.XPath("//input[@aria-describedby='setMyWarehouseLocation1']");
        private readonly By StoreDetailsButtonLocator = By.XPath("//a[@automation-id='storeDetailsLink_1']");
        private readonly By WarehouseNameLocator = By.XPath("//a[@automation-id='warehouseNames_1']");
        private readonly By WarehouseAddressLocator = By.XPath("//span[@automation-id='warehouseAddressLine1Output_1']");
        private readonly By WarehouseTableLocator = By.Id("warehouse-list");

        public InputField WarehouseSearch => new(WarehouseSearchLocator);
        public Button FindButton => new(FindButtonLocator);
        public Button SetAsMyWarehouseButton => new(SetAsMyWarehouseButtonLocator);
        public Button StoreDetailsButton => new(StoreDetailsButtonLocator);
        public TextBox WarehouseName => new(WarehouseNameLocator);
        public TextBox WarehouseAddress => new(WarehouseAddressLocator);
        public Table WarehouseTable => new(WarehouseTableLocator);
        public LocationsBlock LocationsBlock => new LocationsBlock();
    }
}