namespace Costco.TestData.Models
{
    public class ProductPageDataModel
    {
        public string ZeroItemsInput { get; init; }
        public string ZeroItemsError { get; init; }

        public string LowCutoffString { get; init; }
        public string HighCutoffString { get; init; }
        public string MemberItemsError { get; init; }

        public string OverMaxItemsInput { get; init; }
        public string OverMaxItemsStepper { get; init; }
        public string OverMaxItemsError { get; init; }
    }
}
