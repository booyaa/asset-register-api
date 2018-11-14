using System.Threading.Tasks;
using HomesEngland.Exception;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetAsset.Models;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.UseCase.GetAsset.Impl
{
    public class GetAssetUseCase : IGetAssetUseCase
    {
        private readonly IAssetReader _assetReader;

        public GetAssetUseCase(IAssetReader assetReader)
        {
            _assetReader = assetReader;
        }
        
        public async Task<GetAssetResponse> ExecuteAsync(GetAssetRequest request)
        {
            if(request == null)
                throw new BadRequestException();
            var validationResponse = request.Validate(request);
            if(!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);
            
            var asset = await _assetReader.ReadAsync(request.Id.Value).ConfigureAwait(false);
            
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