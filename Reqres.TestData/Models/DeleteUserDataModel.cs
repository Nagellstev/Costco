using Costco.TestData.Models;

namespace Reqres.TestData.Models
{
    public class DeleteUserDataModel : IConvertibleTestData
    {
        public int UserID { get; init; }
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
