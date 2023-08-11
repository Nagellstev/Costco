namespace Costco.TestData.Models
{
    public class ProductPageDataModel
    {
        public string ZeroItemsInput { get; set; }
        public string ZeroItemsError { get; set; }

        public string LowCutoffString { get; set; }
        public string HighCutoffString { get; set; }
        public string MemberItemsError { get; set; }

        public string OverMaxItemsInput { get; set; }
        public string OverMaxItemsStepper { get; set; }
        public string OverMaxItemsError { get; set; }
    }
}
