namespace Costco.TestData.Models
{
    public class LocationsModel: IConvertibleTestData
    {
        public string Warehouse { get; init; }
        public string DeliveryLocation { get; init; }

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
