namespace HomesEngland.UseCase.ImportAssets.Models.ParserExtensions
{
    public static class DecimalParserExtension
    {
        public static decimal? TryParseDecimalNullable(this string str, string strip = "")
        {
            decimal? value = null;
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                {
                    if(!string.IsNullOrEmpty(strip) && !string.IsNullOrWhiteSpace(strip))
                        str = str.Replace(strip, "");
                    value = decimal.Parse(str);
                }
                    
            }
            catch { }

            return value;
        }
    }
}
