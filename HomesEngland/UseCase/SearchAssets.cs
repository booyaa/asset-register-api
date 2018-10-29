using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;

namespace HomesEngland.UseCase
{
    public class SearchAssets:ISearchAssetsUseCase
    { 
        private IAssetGateway Gateway { get;}

        public SearchAssets(IAssetGateway gateway)
        {
            Gateway = gateway;
        }

        public async Task<Dictionary<string, string>[]> Execute(string query)
        {
            Asset[] results = await Gateway.SearchAssets(query);
            return results.Select(t => t.ToDictionary()).ToArray();
        }
    }
}