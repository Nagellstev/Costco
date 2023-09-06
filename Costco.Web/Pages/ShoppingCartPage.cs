using Costco.Core.Browser;
using Costco.Core.Elements;
using Costco.Web.Blocks;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Costco.Web.Pages
{
    public class ShoppingCartPage
    {
        public readonly By ListOfItemsPath = By.XPath("//*[@id='order-items-regular']");
        private ElementList _listOfItems => new(ListOfItemsPath);

        public Dictionary<string, ShoppingItemBlock> ListOfItems
        {
            get
            {
                Dictionary<string, ShoppingItemBlock> list = new();
                foreach (var item in _listOfItems.GetElements(By.XPath("div")))
                {
                    ShoppingItemBlock block = new(item);
                    list.Add(block.ItemName.Text, block);
                }

                return list;
            }
        }


    }
}
