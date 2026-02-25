using Hotel.Models;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Text.RegularExpressions;
using TimeZoneConverter;

namespace Hotel.Common
{
    public static class CommonMethods
    {
        public static string RemoveAllWhitespace(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return Regex.Replace(input, @"\s+", "");
        }
        public static string AddSpaceAfter5thChar(this string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length <= 5)
                return input;

            return input.Insert(5, " ");
        }
        public static DateTime GetIndianTime(this DateTime utcTime)
        {
            var istZone = TZConvert.GetTimeZoneInfo("Asia/Kolkata"); // Cross-platform safe
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, istZone);

            //return utcTime.AddHours(5).AddMinutes(30); 
        }
        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                  .FirstOrDefault() as DescriptionAttribute;

            return attribute != null ? attribute.Description : value.ToString();
        }
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public static bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        public static string GetConnectionString()
        {
            // Build the configuration object
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Retrieve the connection string by name
            return config.GetConnectionString("DefaultConnection")!;
        }
    }

    public static class AppSession
    {
        public static TblUser? CurrentUser { get; set; }
        public static List<string> Roles { get; set; } = new List<string>();

        public static bool IsInRole(string roleName) =>
            Roles.Any(r => r.Equals(roleName, StringComparison.OrdinalIgnoreCase));

        public static void Logout()
        {
            CurrentUser = null;
            Roles.Clear();
        }
    }
}
