using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Pages
{
    public class WarehousePage: BasePage
    {
        public readonly By nameLocator = By.XPath("//h1[@automation-id='warehouseNameOutput']");
        public readonly By addressLocator = By.XPath("//span[@automation-id='streetAddressOutput']");

        public TextBox Name => new(nameLocator);
        public TextBox Address => new(addressLocator);

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