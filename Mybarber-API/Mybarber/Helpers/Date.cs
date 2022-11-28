using System;
using TimeZoneConverter;

namespace Mybarber.Helpers
{
    public class Date
    {
        public static DateTime GetNow()
        {
            string tz = TZConvert.WindowsToIana("E. South America Standard Time");
            var brasilia = TimeZoneInfo.FindSystemTimeZoneById(tz);
            var horaBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasilia);
            return horaBrasilia;
        }
    }
}
