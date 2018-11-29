using System;
using System.Collections.Generic;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.SearchAsset.Models
{
    public class SearchAssetResponse
    {
        public IList<AssetOutputModel> Assets { get; set; }
        public int Pages { get; set; }
        public int TotalCount { get; set; }
    }
}
