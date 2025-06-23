using System.Text.RegularExpressions;

namespace Shared.Utilities
{
    public class UtilitiesHelper
    {
        public static string Encode(string ToEncode)
        {
            return BCrypt.Net.BCrypt.HashPassword(ToEncode);
        }

        public static bool VerifyPassword(string storedPassword, string inputPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedPassword);
        }

        public static bool CheckPassword(string password)
        {
            const string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
