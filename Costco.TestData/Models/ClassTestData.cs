using Costco.TestData.Models.ProductPage;
using Costco.Utilities.FileReader;
using Xunit.Sdk;
using System.Reflection;

namespace Costco.TestData.Models
{
    public class ClassTestData: DataAttribute
    {
        private object _classDataModel;
        internal string TestDataFile { get; init; }
        internal Type TestDataClassModel { get; init; }
        internal PropertyInfo TestDataModel { get; init; }

        public ClassTestData(string testDataFile, Type testDataClassModel, string testDataModel)
        {
            TestDataFile = testDataFile;
            TestDataClassModel = testDataClassModel;
            TestDataModel = TestDataClassModel.GetProperty(testDataModel);
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            FileReader reader = new();
            _classDataModel = reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", TestDataFile),
                TestDataClassModel.AssemblyQualifiedName);

            object testDataModelInstance = TestDataModel.GetValue(_classDataModel);
            Type testDataModelType = TestDataModel.GetValue(_classDataModel).GetType();


            return (IEnumerable<object[]>)testDataModelType.GetProperty("GenericData").GetValue(testDataModelInstance);
        }
    }
}
