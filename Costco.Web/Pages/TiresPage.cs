using Costco.Web.Blocks;
﻿using Costco.Core.Browser;
using Costco.Core.Elements;
using OpenQA.Selenium;

namespace Costco.Web.Pages
{
    public class TiresPage : BasePage
    {
        public readonly By SearchBySizeButtonLocator = By.Id("size");
        public readonly By WidthMenuLocator = By.Id("ddlWidth");
        public readonly By AspectMenuLocator = By.Id("ddlAspect");
        public readonly By RimMenuLocator = By.Id("ddlRim");
        public readonly By FindTiresButtonLocator = By.Id("btnFindTiresBySize");
        public readonly By PostalCodeInputLocator = By.Id("txtZipCodeBySize"); 
        public readonly By SelectTireCenterLabelLocator = By.Id("SearchWarehouseLabel");
        public readonly By AcceptAllCookiesButtonLocator = By.Id("onetrust-accept-btn-handler");

        public Button AcceptAllCookiesButton => new Button(AcceptAllCookiesButtonLocator);
        public Button SearchBySizeButton => new Button(SearchBySizeButtonLocator);
        public Button FindTiresButton => new Button(FindTiresButtonLocator);
        public InputField PostalCodeInput => new InputField(PostalCodeInputLocator);
        public TextBox SelectTireCenterLabel => new (SelectTireCenterLabelLocator);

        public DropdownOnClickSelectBlock WidthSelectBlock => new DropdownOnClickSelectBlock(WidthMenuLocator);
        public DropdownOnClickSelectBlock AspectSelectBlock => new DropdownOnClickSelectBlock(AspectMenuLocator);
        public DropdownOnClickSelectBlock RimSelectBlock => new DropdownOnClickSelectBlock(RimMenuLocator);
    }
}
