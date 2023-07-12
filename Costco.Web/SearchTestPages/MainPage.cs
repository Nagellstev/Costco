using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;

namespace Costco.Web.SearchTestPages
{
    public class MainPage : BasePage
    {
        public By SearchFieldLocator => By.Id("search-field");
        public InputField SearchField => new InputField(SearchFieldLocator);

        //public void Search(string searchText)
        //{
        //    SearchField.SendKeys(searchText);
        //}
    }
}