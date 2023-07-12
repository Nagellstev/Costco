using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costco.TestData.Models
{
    public class LoginCredentialsModel
    {
        public class Root
        {
            public ValidCredentials ValidCredentials { get; set; }
            public InvalidCredentials InvalidCredentials { get; set; }
        }

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
