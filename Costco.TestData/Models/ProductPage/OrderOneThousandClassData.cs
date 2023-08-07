namespace Costco.TestData.Models.ProductPage
{
    public class OrderOneThousandClassData : BaseClassData
    {
        internal override string TestDataFileName { get; } = "ProductPageTestData.json";
        internal override string TestDataNodeName { get; } = "ExceedMaximumAmountOfItemsInCartInputFieldTest";
    }
}
