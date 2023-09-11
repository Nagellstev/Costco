using System.Collections;

namespace Costco.TestData.Models
{
    public class TestDataModel<IConvertibleTestData>
    {
        public IConvertibleTestData[] TestDataArray { get; init; }
    }
}
