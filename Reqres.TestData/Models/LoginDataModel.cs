using Costco.TestData.Models;

namespace Reqres.TestData.Models
{
    public class LoginDataModel : IConvertibleTestData
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public int ExpectedStatusCode { get; init; }
        public string ExpectedMessage { get; init; }

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
