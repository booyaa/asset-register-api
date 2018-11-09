using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.UseCase.Assets.Models;

namespace HomesEngland.UseCase.Assets
{
    public class GetAssets:IGetAssets
    {
        private readonly IAssetsRetriever _assetsRetriever;
        
        public GetAssets(IAssetsRetriever assetsRetriever)
        {
            _assetsRetriever = assetsRetriever;
        }

        public async Task<GetAssetsResponse> Execute(GetAssetsRequest request)
        {
            IList<Asset> assets = await _assetsRetriever.GetAssets(request?.Ids);

            if (assets == null)
                throw new NoAssetException();

            return assets;
        }
    }
}