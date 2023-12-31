﻿using Costco.Core.Browser;
using Costco.Web.Pages;
using System.Text.RegularExpressions;

namespace Costco.Web.Steps
{
    public class SearchResultsPageSteps
    {
        private SearchResultsPage _searchResultsPage;

        public SearchResultsPageSteps(SearchResultsPage searchResultsPage)
        {
            _searchResultsPage = searchResultsPage;
        }

        public string ReadSearchResultsMessage()
        {
            //Waiters.WaitForCondition(() => _searchResultsPage.SearchResultsMessage.IsDisplayed(), 10);
            return _searchResultsPage.SearchResultsMessage.Text;
        }

        public string NothingFoundMessage()
        {
            //Waiters.WaitForCondition(() => _searchResultsPage.NothingFoundMessage.IsDisplayed(), 10);
            return _searchResultsPage.NothingFoundMessage.Text;
        }

        public void FilterByPrice(string priceRange)
        {
            Waiters.WaitForCondition(() => _searchResultsPage.FilterBlock.IsDisplayed(), 10);
            for (int i = 0; i < _searchResultsPage.FilterBlock.PriceCheckBoxes.Count; i++)
            {
                if (_searchResultsPage.FilterBlock.PriceCheckBoxes[i].Text.Contains(priceRange))
                {
                    _searchResultsPage.FilterBlock.PriceCheckBoxes[i].Click();
                }
            }
        }

        public int GetTotalQuantity()
        {
            //Waiters.WaitForCondition(() => _searchResultsPage.TotalProductsShowingQuantity.IsDisplayed(), 10);
            string totalProductsShowingQuantity = _searchResultsPage.TotalProductsShowingQuantity.Text;
            return ExtractTotalQuantity(totalProductsShowingQuantity);
        }

        private int ExtractTotalQuantity(string text)
        {
            //regex extracts number from the end of the string
            Regex regex = new Regex(@"\d{1,}$");
            Match match = regex.Match(text);
            return int.Parse(match.Value);
        }
    }
}
