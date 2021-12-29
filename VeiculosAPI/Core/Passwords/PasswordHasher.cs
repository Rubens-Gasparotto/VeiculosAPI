using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace VeiculosAPI.Core.Passwords
{
    public class PasswordHasher
    {
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Check(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
            ;
        }
    }
}
