using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using HomesEngland.Exception;

namespace HomesEngland.UseCase
{
    public class GetAssets:IGetAssets
    {
        private readonly IAssetsRetriever _assetsRetriever;
        
        public GetAssets(IAssetsRetriever assetsRetriever)
        {
            _assetsRetriever = assetsRetriever;
        }

        public async Task<Dictionary<string,string>[]> Execute(int[] id)
        {
            Asset[] assets = await _assetsRetriever.GetAssets(id);

            if (assets == null) throw new NoAssetException();
            
            return assets.Select(_ => _.ToDictionary()).ToArray();
        }
    }
}