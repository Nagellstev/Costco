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
    }
}