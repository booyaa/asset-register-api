using System;
using System.Linq;
using HomesEngland.UseCase.ImportAssets.Models;

namespace HomesEngland.UseCase.GenerateAssets
{
    public class ImportAssetInputParser : IInputParser<ImportAssetsRequest>
    {
        public ImportAssetsRequest Parse(string[] args)
        {
            string delimiter = null;
            if (args != null && args.Length >= 4)
            {
                if (args.ElementAt(2).Equals("--delimiter", StringComparison.OrdinalIgnoreCase))
                {
                    delimiter = args.ElementAtOrDefault(3);
                }
            }
            var request = new ImportAssetsRequest
            {
                Delimiter = delimiter
            };
            return request;
        }
    }
}
