using System.Collections.Generic;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.GenerateAssets.Models
{
    public class GenerateAssetsResponse
    {
        public IList<AssetOutputModel> RecordsGenerated { get; set; }
    }
}
