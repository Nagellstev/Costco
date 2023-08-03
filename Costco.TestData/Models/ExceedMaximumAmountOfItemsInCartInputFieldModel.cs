using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public class ExceedMaximumAmountOfItemsInCartInputFieldModel: IEnumerable<object[]>
    {
        private DataContainer _container;

        public IEnumerator<object[]> GetEnumerator()
        {
            FileReader reader = new();
            _container = (DataContainer)reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", "ExceedMaximumAmountOfItemsInCartInputFieldTestData.json"),
                typeof(DataContainer).AssemblyQualifiedName);
            return _container.TestData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
