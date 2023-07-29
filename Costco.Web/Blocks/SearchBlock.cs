using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Blocks
{
    public class SearchBlock : BaseBlock
    {
        public By SearchFieldLocator => By.Id("search-field");
        public InputField SearchField => new InputField(SearchFieldLocator);

        public SearchBlock(By locator) : base(locator) { }
    }
}