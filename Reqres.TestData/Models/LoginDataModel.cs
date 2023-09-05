namespace Reqres.TestData.Models
{
    public class LoginDataModel
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public int ExpectedStatusCode { get; init; }
        public string ExpectedMessage { get; init; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
