using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway;
using HomesEngland.UseCase.GetAsset.Models;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.UseCase.GetAsset
{
    public class GetAssetUseCase : IGetAssetUseCase
    {
        private readonly IDatabaseEntityReader<Asset, int> _databaseEntityGateway;

        public GetAssetUseCase(IDatabaseEntityReader<Asset, int> databaseEntityGateway)
        {
            _databaseEntityGateway = databaseEntityGateway;
        }
        
        public async Task<GetAssetResponse> ExecuteAsync(GetAssetRequest request)
        {
            //validate   
            if(request == null)
                throw new BadRequestException();
            var validationResponse = request.Validate(request);
            if(!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);
            
            var asset = await _databaseEntityGateway.ReadAsync(request.Id.Value).ConfigureAwait(false);
            
            if (asset == null)
                throw new AssetNotFoundException();

            var response = new GetAssetResponse
            {
                Asset = new AssetOutputModel(asset)
            };
            return response;
        }
    }
}