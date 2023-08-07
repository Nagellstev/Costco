using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public abstract class BaseClassData : IEnumerable<object[]>
    {
        private DataModel _container;
        internal abstract string TestDataFileName { get; }
        internal abstract string TestDataNodeName { get; }

        public IEnumerator<object[]> GetEnumerator()
        {
            FileReader reader = new();
            _container = (DataModel)reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", TestDataFileName),
                typeof(DataModel).AssemblyQualifiedName, TestDataNodeName);
            return _container.Data.GetEnumerator(); //warning, implicit conversion from string to object
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
