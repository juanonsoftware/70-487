using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace ChattyServices
{
    public class CustomUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("UserName can't be empty", "userName");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password can't be empty", "password");
            }

            if (!string.Equals(userName, password))
            {
                throw new FaultException("Invalid username/password");
            }
        }
    }
}