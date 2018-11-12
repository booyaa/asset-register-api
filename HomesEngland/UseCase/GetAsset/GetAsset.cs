using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.GetAsset
{
    public class GetAsset : IGetAsset
    {
        private readonly IEntityReader<Asset, int> _entityGateway;

        public GetAsset(IEntityReader<Asset, int> entityGateway)
        {
            _entityGateway = entityGateway;
        }
        
        public async Task<GetAssetResponse> ExecuteAsync(GetAssetRequest request)
        {
            //validate   
            var asset = await _entityGateway.ReadAsync(request.Id.Value).ConfigureAwait(false);
            
            if (asset == null)
                throw new NoAssetException();

            var response = new GetAssetResponse
            {
                Asset = new AssetOutputModel(asset)
            };
            return response;
        }
    }
}