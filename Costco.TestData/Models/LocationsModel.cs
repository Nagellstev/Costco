namespace Costco.TestData.Models
{
    public class LocationsModel
    {
        public string Warehouse { get; init; }
        public string DeliveryLocation { get; init; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
