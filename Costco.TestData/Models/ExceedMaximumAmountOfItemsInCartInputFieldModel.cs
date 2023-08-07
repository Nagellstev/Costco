using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public class ExceedMaximumAmountOfItemsInCartInputFieldModel: BaseModel
    {
        internal override string testDataFileName { get; } = "ProductPageTestData.json";
        internal override string testDataNodeName { get; } = "ExceedMaximumAmountOfItemsInCartInputFieldTest";
    }
}
