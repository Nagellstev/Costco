using Costco.Web.Blocks;
﻿using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class MainPageCa : BasePage
    {
        public readonly By TiresLocator = By.XPath("//div[@id='navigation-widget']//a[contains(@href,'tires')]");

        public Button TiresButton => new Button(TiresLocator);
    }
}
