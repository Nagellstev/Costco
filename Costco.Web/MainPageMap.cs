using OpenQA.Selenium;

namespace Costco.Web
{
    public class MainPageMap: BasePageMap
    {
        public By SearchField => By.Id("search-field");
    }
}
