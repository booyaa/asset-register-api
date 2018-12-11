namespace HomesEngland.UseCase.ImportAssets.Models.ParserExtensions
{
    public static class BoolParserExtension
    {
        public static bool? TryParseBoolNullable(this string str)
        {
            bool? value = null;
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    value = bool.Parse(str);
            }
            catch { }

            return value;
        }
    }
}