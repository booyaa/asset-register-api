using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using HomesEngland.Exception;

namespace HomesEngland.UseCase.Assets
{
    public class GetAsset : IGetAsset
    {
        private readonly IAssetRetriever _assetRetriever;
        
        public GetAsset(IAssetRetriever assetRetriever)
        {
            _assetRetriever = assetRetriever;
        }
        
        public async Task<Dictionary<string,string>> Execute(int id)
        {
            Asset asset = await _assetRetriever.GetAsset(id);
            
            if (asset == null) throw new NoAssetException();
            
            return asset.ToDictionary();
        }
    }
}