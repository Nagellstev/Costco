using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Blocks
{
    public class SearchBlock : BaseBlock
    {
        private static readonly By searchBlockLocator = By.Id("formcatsearch");

        public SearchBlock() : base(searchBlockLocator) { }

        public By SearchFieldLocator => By.Id("search-field");
        public InputField SearchField => new InputField(SearchFieldLocator);
    }
}