using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;

namespace HomesEngland.UseCase
{
    public class SearchAssets:ISearchAssets
    {
        private readonly IAssetSearcher _assetSearcher;

        public SearchAssets(IAssetSearcher assetSearcher)
        {
            _assetSearcher = assetSearcher;
        }

        public async Task<Dictionary<string, string>[]> Execute(string query)
        {
            Asset[] results = await _assetSearcher.SearchAssets(query);
            return results.Select(t => t.ToDictionary()).ToArray();
        }
    }
}