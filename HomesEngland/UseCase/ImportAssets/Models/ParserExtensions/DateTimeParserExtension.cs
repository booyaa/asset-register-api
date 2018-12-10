using System;

namespace HomesEngland.UseCase.ImportAssets.Models.ParserExtensions
{
    public static class DateTimeParserExtension
    {
        public static DateTime? TryParseDateTimeNullable(this string str)
        {
            DateTime? dateTime = null;
            try
            {
                if(!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    dateTime = DateTime.Parse(str);
            }
            catch { }

            return dateTime;
        }
    }

    public static class DecimalParserExtension
    {
        public static decimal? TryParseDecimalNullable(this string str)
        {
            decimal? value = null;
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    value = decimal.Parse(str);
            }
            catch { }

            return value;
        }
    }
}
