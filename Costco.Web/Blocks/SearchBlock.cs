using OpenQA.Selenium;
using Costco.Core.Elements;

namespace Costco.Web.Blocks
{
    public class SearchBlock : BaseBlock
    {
        private static readonly By searchBlockLocator = By.Id("formcatsearch");
        public readonly By searchFieldLocator = By.Id("search-field");

        public SearchBlock() : base(searchBlockLocator) { }

        public InputField SearchField => new InputField(searchFieldLocator);
    }
}