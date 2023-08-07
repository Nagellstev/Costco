using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public abstract class BaseModel: IEnumerable<object[]>
    {
        private DataContainer _container;
        internal abstract string testDataFileName { get; }
        internal abstract string testDataNodeName { get; }

        public IEnumerator<object[]> GetEnumerator()
        {
            FileReader reader = new();
            _container = (DataContainer)reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", testDataFileName),
                typeof(DataContainer).AssemblyQualifiedName, testDataNodeName);
            return _container.Data.GetEnumerator(); //warning, implicit conversion from string to object
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
