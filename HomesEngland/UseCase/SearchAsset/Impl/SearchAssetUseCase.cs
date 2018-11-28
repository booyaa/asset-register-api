using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.UseCase.SearchAsset.Impl
{
    public class SearchAssetUseCase : ISearchAssetUseCase
    {
        private readonly IAssetSearcher _assetSearcher;

        public SearchAssetUseCase(IAssetSearcher assetSearcher)
        {
            _assetSearcher = assetSearcher;
        }

        public async Task<SearchAssetResponse> ExecuteAsync(SearchAssetRequest request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            var foundAssets = await SearchAssets(request, cancellationToken);

            var response = new SearchAssetResponse
            {
                Assets = foundAssets?.Select(s => new AssetOutputModel(s)).ToList()
            };

            return response;
        }

        private async Task<IList<IAsset>> SearchAssets(SearchAssetRequest request, CancellationToken cancellationToken)
        {
            var assetSearch = new AssetSearchQuery
            {
                SchemeId = request.SchemeId,
                Address = request.Address
            };
            var foundAssets = await _assetSearcher.Search(assetSearch, cancellationToken).ConfigureAwait(false);

            if (foundAssets == null)
                foundAssets = new List<IAsset>();

            return foundAssets;
        }

        private void ValidateRequest(SearchAssetRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException();
            }

            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
            {
                throw new BadRequestException(validationResponse);
            }
        }
    }
}
