﻿using OpenQA.Selenium;

namespace Costco.Web.Elements
{
    public class Menu : BaseElement
    {
        public Menu(By locator) : base(locator)
        {

        }

        public Menu(IWebElement element) : base(element)
        {

        }
    }
}