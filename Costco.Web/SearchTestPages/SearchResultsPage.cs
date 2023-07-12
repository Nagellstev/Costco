using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace Costco.Web.SearchTestPages
{
    public class SearchResultsPage : BasePage
    {
        public By SearchResultsMessageLocator => By.Id("rsltCntMsg");
        public TextBox SearchResultsMessage => new TextBox(SearchResultsMessageLocator);
        public By PriceCheckBox0to25Locator => By.XPath("//button[@id = 'accordion-filter_collapse-1']//label//span[text('$0 to $25')]");
        public CheckBox PriceCheckBox0to25 => new CheckBox(PriceCheckBox0to25Locator);
        public By TotalProductsShowingQuantityLocator => By.CssSelector("span[automation-id='totalProductsOutputText']");
        public TextBox TotalProductsShowingQuantity => new TextBox(TotalProductsShowingQuantityLocator);

        //public string ReadSearchResultsMessage()
        //{
        //    return SearchResultsMessage.Text;
        //}

        //public void FilterByPrice0to25()
        //{
        //    PriceCheckBox0to25.Click();
        //}

        //public int CheckTotalQuantity()
        //{
        //    string str = TotalProductsShowingQuantity.Text;
        //    return ExtractTotalQuantity(str);
        //}

        //private int ExtractTotalQuantity(string text)
        //{
        //    //extract number from the end of the string
        //    Regex regex = new Regex(@"\d{1,}$");
        //    Match match = regex.Match(text);
        //    return int.Parse(match.Value);
        //}
    }
}
