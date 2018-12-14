using HomesEngland.Domain;

namespace HomesEngland.Gateway.Assets
{
    public interface IAssetAggregator : IDatabaseEntityAggregator<IAsset, int, IAssetSearchQuery, IAssetAggregation>
    {

    }
}
