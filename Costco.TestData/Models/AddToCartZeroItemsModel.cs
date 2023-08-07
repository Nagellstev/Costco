
namespace Costco.TestData.Models
{
    public class AddToCartZeroItemsModel : BaseModel
    {
        internal override string testDataFileName { get; } = "ProductPageTestData.json";
        internal override string testDataNodeName { get; } = "AddToCartZeroItemsTest";
    }
}
