namespace Costco.TestData.Models.ProductPage
{
    public class LimitedMemberItemsClassData : BaseClassData
    {
        internal override string TestDataFileName { get; } = "ProductPageTestData.json";
        internal override string TestDataNodeName { get; } = "AddToCartMoreLimitedItemsThanAllowedTest";
    }
}
