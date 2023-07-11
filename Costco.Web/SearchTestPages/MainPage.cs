using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.SearchTestPages
{
    public class MainPage : BasePage
    {
        public InputField SearchField => new InputField(By.Id("search-field"));

        public void Search(string searchText)
        {
            SearchField.SendKeys(searchText);
        }
    }
}