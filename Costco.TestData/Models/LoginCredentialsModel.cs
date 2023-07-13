namespace Costco.TestData.Models
{
    public class LoginCredentialsModel
    {
        public class Root
        {
            public ValidCredentials ValidCredentials { get; init; }
            public InvalidCredentials InvalidCredentials { get; init; }
        }

        public class InvalidCredentials
        {
            public string Username { get; init; }
            public string Password { get; init; }
        }

        public class ValidCredentials
        {
            public string Username { get; init; }
            public string Password { get; init; }
        }
    }
}
