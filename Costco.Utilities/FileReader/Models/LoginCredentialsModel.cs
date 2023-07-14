namespace Costco.Utilities.FileReader.Models
{
    public class LoginCredentialsModel
    {
            public ValidCredentials ValidCredential { get; set; }
            public InvalidCredentials InvalidCredential { get; set; }

        public class InvalidCredentials
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class ValidCredentials
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
