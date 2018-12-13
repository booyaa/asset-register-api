using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.CalculateAssetAggregates.Models;

namespace HomesEngland.UseCase.CalculateAssetAggregates
{
    public class CalculateAssetAggregatesUseCase: ICalculateAssetAggregatesUseCase
    {
        private readonly IAssetAggregator _assetAggregator;

        public CalculateAssetAggregatesUseCase(IAssetAggregator assetAggregator)
        {
            _assetAggregator = assetAggregator;
        }

        public async Task<CalculateAssetAggregateResponse> ExecuteAsync(CalculateAssetAggregateRequest request, CancellationToken cancellationToken)
        {
            var assetSearchQuery = new AssetSearchQuery
            {
                SchemeId = request?.SchemeId,
                Address = request?.Address
            };
            var result = await _assetAggregator.Aggregate(assetSearchQuery, cancellationToken).ConfigureAwait(false);
            var response = new CalculateAssetAggregateResponse
            {
                AssetAggregates = new AssetAggregatesOutputModel(result)
            };
            return response;
        }
    }
}
