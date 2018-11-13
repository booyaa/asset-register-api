using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.GetAsset
{
    public class GetAsset : IGetAsset
    {
        private readonly IDatabaseEntityReader<Asset, int> _databaseEntityGateway;

        public GetAsset(IDatabaseEntityReader<Asset, int> databaseEntityGateway)
        {
            _databaseEntityGateway = databaseEntityGateway;
        }
        
        public async Task<GetAssetResponse> ExecuteAsync(GetAssetRequest request)
        {
            //validate   
            var asset = await _databaseEntityGateway.ReadAsync(request.Id.Value).ConfigureAwait(false);
            
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