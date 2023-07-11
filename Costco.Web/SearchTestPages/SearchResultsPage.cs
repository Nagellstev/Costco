using Costco.Core.BasePage;
using Costco.Web.Elements;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace Costco.Web.SearchTestPages
{
    public class SearchResultsPage : BasePage
    {
        public TextBox SearchResultsMessage => new TextBox(By.Id("rsltCntMsg"));
        public CheckBox PriceCheckBox0to25 => new CheckBox(By.XPath("//button[@id = 'accordion-filter_collapse-1']//label//span[text('$0 to $25')]"));
        public TextBox TotalProductsShowingQuantity => new TextBox(By.CssSelector("span[automation-id='totalProductsOutputText']"));

        public string ReadSearchResultsMessage()
        {
            return SearchResultsMessage.Text;
        }

        public void FilterByPrice0to25()
        {
            PriceCheckBox0to25.Click();
        }

        public int CheckTotalQuantity()
        {
            string str = TotalProductsShowingQuantity.Text;
            return ExtractTotalQuantity(str);
        }

        private int ExtractTotalQuantity(string text)
        {
            //extract number from the end of the string
            Regex regex = new Regex(@"\d{1,}$");
            Match match = regex.Match(text);
            return int.Parse(match.Value);
        }
    }
}
