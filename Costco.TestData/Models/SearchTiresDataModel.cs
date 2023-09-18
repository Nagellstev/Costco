namespace Costco.TestData.Models
{
    public class SearchTiresDataModel : IConvertibleTestData
    {
        public string TireWidth { get; init; }
        public string TireAspect { get; init; }
        public string TireRim { get; init; }
        public string PostalCode { get; init; }

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
