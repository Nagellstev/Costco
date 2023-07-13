﻿using OpenQA.Selenium;
using Costco.Web.Elements;
using OpenQA.Selenium.DevTools.V112.Tracing;

namespace Costco.Web.Pages
{
    public class WarehousePage: BasePage
    {
        public By NameLocator = By.XPath("//h1[@automation-id='warehouseNameOutput']");
        public By AddressLocator = By.XPath("//span[@automation-id='streetAddressOutput']");

        public TextBox Name => new(NameLocator);
        public TextBox Address => new(AddressLocator);

        public string GetName()
        {
            return Name.Text;
        }

        public string GetAddress()
        {
            return Address.Text;
        }
    }
}