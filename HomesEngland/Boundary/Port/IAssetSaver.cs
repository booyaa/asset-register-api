using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Boundary.Port
{
    public interface IAssetSaver
    {
        Task<int> AddAsset(Asset asset);
    }
}