using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Boundary.Port
{
    public interface IAssetRetriever
    {
        Task<Asset> GetAsset(int id);
    }
}