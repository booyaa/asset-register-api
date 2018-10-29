using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Boundary
{
    public interface IAssetGateway
    {
        Task<Asset> GetAsset(int id);
        Task<int> AddAsset(Asset asset);
        Task<Asset[]> GetAssets(int[] ids);
        Task<Asset[]> SearchAssets(string searchQuery);
    }
}