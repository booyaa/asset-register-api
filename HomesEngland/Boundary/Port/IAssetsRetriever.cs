using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.UseCase.Assets.Models;

namespace HomesEngland.Boundary.Port
{
    public interface IAssetsRetriever
    {
        Task<IList<Asset>> GetAssets(IList<int> request);
    }
}