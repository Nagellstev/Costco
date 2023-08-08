namespace Costco.TestData.Models.ProductPage
{
    public class ProductPageDataModel
    {
        public ZeroItemsDataModel AddToCartZeroItemsTest { get; init; }
        public LimitedMemberItemsDataModel AddToCartMoreLimitedItemsThanAllowedTest { get; init; }
        public OrderOneThousandDataModel ExceedMaximumAmountOfItemsInCartInputFieldTest { get; init; }
    }
}
