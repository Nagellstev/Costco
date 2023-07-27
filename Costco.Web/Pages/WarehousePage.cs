using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Pages
{
    public class WarehousePage: BasePage
    {
        public readonly By NameLocator = By.XPath("//h1[@automation-id='warehouseNameOutput']");
        public readonly By AddressLocator = By.XPath("//span[@automation-id='streetAddressOutput']");

        public TextBox Name => new(NameLocator);
        public TextBox Address => new(AddressLocator);

        public string GetName()
        {
            return Name.Text[..Name.Text.IndexOf(" ")];
        }

        public string GetAddress()
        {
            return Address.Text;
        }
    }
}