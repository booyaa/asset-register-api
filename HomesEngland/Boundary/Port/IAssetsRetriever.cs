using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Boundary.Port
{
    public interface IAssetsRetriever
    {
        Task<Asset[]> GetAssets(int[] ids);
    }
}