namespace Costco.TestData.Models
{
    public class LoginCredentialsModel: IConvertibleTestData
    {
        public string ValidUsername { get; init; }
        public string ValidPassword { get; init; }
        public string InvalidUsername { get; init; }
        public string InvalidPassword { get; init; }

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

