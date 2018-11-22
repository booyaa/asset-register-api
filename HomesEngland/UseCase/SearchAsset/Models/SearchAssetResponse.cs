using System.Collections.Generic;

namespace HomesEngland.UseCase.GetAsset.Models
{
    public class SearchAssetResponse
    {
        public IList<AssetOutputModel> Assets { get; set; }
    }
}