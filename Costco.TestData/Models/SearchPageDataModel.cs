namespace Costco.TestData.Models
{
    public class SearchPageDataModel: IConvertibleTestData
    {
        public string SearchExistingItem { get; init; }
        public string SearchExistingItemResult { get; init; }
        public string SearchSenselessLine { get; init; }
        public string SearchSenselessLineResult { get; init; }
        public string SearchExistingItemAndFilterByPriceSearch { get; init; }
        public string SearchExistingItemAndFilterByPriceFilter { get; init; }

        public object[] ConvertToInlineData()
        {
            return new object[] { this };
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
