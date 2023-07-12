using Costco.Web.SearchTestPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costco.Web.SearchTestSteps1
{
    public class BaseSteps
    {
        public MainPage mainPage;
        public SearchResultsPage searchResultsPage;

        public BaseSteps()
        {
            mainPage = new MainPage();
            searchResultsPage = new SearchResultsPage();
        }

        //1. Go to https://www.costco.com/ page
        //2. Send keys «vitamin» to the search field
        //result. Header of search results contains substring «vitamin»

        public string GetHeaderText(string searchInput)
        {
            mainPage.Search(searchInput);
            return searchResultsPage.ReadSearchResultsMessage();
        }

        //1. Go to https://www.costco.com/ page
        //2. Send keys «vitamin» to the search field
        //3. Extract total quantity from string "showing 1-XX from YY"
        //4. Choose $0 to $25 option in "Price" filter area
        //5. Extract total quantity from string "showing 1-XX from ZZ"
        //result. Total quantity is updated

        public string 

        //1. Go to https://www.costco.com/ page
        //2. Send keys «qwerty» to the search field
        //result. Header of search results contains substring «we were not able to find a match»


    } 
}
