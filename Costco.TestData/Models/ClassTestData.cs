using Costco.TestData.Models;
using Costco.Utilities.FileReader;
using Xunit.Sdk;
using System.Reflection;

namespace Costco.TestData.Models
{
    public class ClassTestData: DataAttribute
    {
        internal string TestDataFile { get; init; }
        internal Type TestDataModel { get; init; }

        public ClassTestData(string testDataFile, Type testDataModel)
        {
            if (testDataModel.GetInterface("IConvertibleTestData") == null) 
            {
                throw new NotSupportedException("Model must implement IConvertibleTestData interface.");
            }

            TestDataFile = testDataFile;
            TestDataModel = testDataModel;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            Type type = typeof(TestDataModel<>).MakeGenericType(TestDataModel);
            object genericTestData = Activator.CreateInstance(type);

            FileReader reader = new();
            genericTestData = reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", TestDataFile),
                genericTestData.GetType().AssemblyQualifiedName);

            List<object[]> returnData = new();
            foreach(var item in (object[])type.GetProperty("TestDataArray").GetValue(genericTestData))
            {
                returnData.Add(((IConvertibleTestData)item).ConvertToInlineData());
            }

            return returnData;
        }
        
    }
}
