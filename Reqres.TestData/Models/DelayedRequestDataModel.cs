using Costco.TestData.Models;

namespace Reqres.TestData.Models
{
    public class DelayedRequestDataModel : IConvertibleTestData
    {
        public int Delay { get; init; }
        public int ExpectedStatusCode { get; init; }

        public object[] ConvertToInlineData()
        {
            return new object[] { this };
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
