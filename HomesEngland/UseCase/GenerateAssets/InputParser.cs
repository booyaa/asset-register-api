using System;
using System.Linq;
using HomesEngland.UseCase.GenerateAssets.Models;

namespace HomesEngland.UseCase.GenerateAssets
{
    public class InputParser: IInputParser
    {
        public GenerateAssetsRequest Parse(string[] args)
        {
            int? records = null;
            if (args != null && args.Length >= 2)
            {
                if (args.ElementAt(0).Equals("--records", StringComparison.OrdinalIgnoreCase) )
                {
                    var recordInput = args.ElementAtOrDefault(1);
                    records = int.Parse(recordInput);
                }
            }
            var request = new GenerateAssetsRequest
            {
                Records = records
            };
            return request;
        }
    }
}
