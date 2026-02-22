using System.Security.Cryptography;
using System.Text;

namespace MyApp.Web.Security
{
    public static class PasswordHasher
    {
        public static string Hash(string value)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(value));
                return System.Convert.ToBase64String(bytes);
            }
        }
    }
}
