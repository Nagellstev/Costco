using OpenQA.Selenium;
using Costco.Web.Elements;

namespace Costco.Web.Pages
{
    public class WarehousePage: BasePage
    {
        public By WarehouseNameLocator = By.XPath("//h1[@automation-id='warehouseNameOutput']");
        public By AddressLocator = By.XPath("//span[@automation-id='streetAddressOutput']");

        public TextBox WarehouseName => new(WarehouseNameLocator);
        public TextBox Address => new(AddressLocator);
    }
}