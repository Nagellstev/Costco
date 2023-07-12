using OpenQA.Selenium;
using Costco.Web.Elements;

namespace Costco.Web.Blocks
{
    public class SearchBlock : BaseBlock
    {
        private static readonly By searchBlockLocator = By.Id("formcatsearch");
        public By SearchFieldLocator => By.Id("search-field");
        public InputField SearchField => new InputField(SearchFieldLocator);
        public SearchBlock() : base(searchBlockLocator) { }
    }
}