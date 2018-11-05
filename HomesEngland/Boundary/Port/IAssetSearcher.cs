using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Boundary.Port
{
    public interface IAssetSearcher
    {
        Task<Asset[]> SearchAssets(string searchQuery);
    }
}