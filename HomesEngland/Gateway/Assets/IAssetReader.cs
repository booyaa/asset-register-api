using HomesEngland.Domain;

namespace HomesEngland.Gateway.Assets
{
    public interface IAssetReader: IDatabaseEntityReader<IAsset, int> 
    {

    }

    public interface IAssetCreator : IDatabaseEntityCreator<IAsset, int>
    {

    }
}
