using HomesEngland.Domain;

namespace HomesEngland.Gateway.Assets
{
    public interface IAssetSearcher: IDatabaseEntitySearcher<IAsset, int, IAssetSearchQuery>
    {

    }
}
