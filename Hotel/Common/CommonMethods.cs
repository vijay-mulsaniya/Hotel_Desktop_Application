using Microsoft.Extensions.Configuration;
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
}
