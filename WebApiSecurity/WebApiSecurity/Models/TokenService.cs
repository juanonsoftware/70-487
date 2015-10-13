using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiSecurity.Models
{
    public class TokenService
    {
        private static readonly IList<Token> Tokens = new List<Token>();

        public static Token GenerateToken()
        {
            var newToken = new Token()
            {
                AuthToken = Guid.NewGuid().ToString(),
                ExpiresOn = DateTime.Now.AddMinutes(10)
            };

            Tokens.Add(newToken);

            return newToken;
        }

        public static bool Validate(string token)
        {
            var existingToken = Tokens.FirstOrDefault(x => x.AuthToken == token);
            if (existingToken == null || existingToken.ExpiresOn < DateTime.Now)
            {
                return false;
            }

            existingToken.ExpiresOn = DateTime.Now.AddMinutes(10);

            return true;
        }
    }
}