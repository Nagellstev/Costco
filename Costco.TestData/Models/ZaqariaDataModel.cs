namespace Costco.TestData.Models
{
    public class ZaqariaDataModel
    {
        public string TireWidth { get; init; }
        public string TireAspect { get; init; }
        public string TireRim { get; init; }
        public string PostalCode { get; init; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
