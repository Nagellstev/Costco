using OpenQA.Selenium;
using Costco.Web.Elements;

namespace Costco.Web.Blocks
{
    public class SearchBlock : BaseBlock
    {
        public static By SearchBlockLocator => By.Id("formcatsearch");
        public By SearchFieldLocator => By.Id("search-field");
        public InputField SearchField => new InputField(SearchFieldLocator);

        public SearchBlock() : base(SearchBlockLocator) { }
    }
}