namespace Costco.TestData.Models
{
    public class LoginCredentialsModel
    {
        public string ValidUsername { get; init; }
        public string ValidPassword { get; init; }
        public string InvalidUsername { get; init; }
        public string InvalidPassword { get; init; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}

