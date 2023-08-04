using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public class AddToCartMoreLimitedItemsThanAllowedModel: BaseModel
    {
        internal override string testDataFileName { get; } = "AddToCartMoreLimitedItemsThanAllowedTestData.json";
    }
}
