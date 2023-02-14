using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace EbolaApp.Models
{
    public static class Utils
    {
        public static string HashPassword(string plainPassword)
        {
            using var hashAlgo = (HashAlgorithm)CryptoConfig.CreateFromName("System.Security.Cryptography.SHA256");

            var passwordBytes = System.Text.Encoding.Unicode.GetBytes(plainPassword);
            var hashPassword = hashAlgo.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashPassword);
        }
        public static bool VerifyPassword(string plainPassword, string hashPassword)
        {
            return HashPassword(plainPassword) == hashPassword;
        }

        public static bool IsValidCredentials(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
                return false;

            var patternRule = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
            return new Regex(patternRule)
                      .IsMatch(email);
        }
    }
}
