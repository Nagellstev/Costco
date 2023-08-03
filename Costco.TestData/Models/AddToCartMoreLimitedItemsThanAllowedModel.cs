using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public class AddToCartMoreLimitedItemsThanAllowedModel: IEnumerable<object[]>
    {
        private DataContainer _container;

        private IEnumerable<object[]> Data()
        {
            FileReader reader = new();
            _container = (DataContainer)reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", "AddToCartMoreLimitedItemsThanAllowedTestData.json"),
                typeof(DataContainer).AssemblyQualifiedName);
            return _container.TestData;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Data().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
