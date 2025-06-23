namespace Shared.Dictionaries
{
    public class AppSettingsInfo
    {
        public static string Issuer { get; set; }
        public static string Audience { get; set; }
        public static string SecretKey { get; set; }
        public static int ExpirationTime { get; set; }
    }
}
