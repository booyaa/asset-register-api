using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.UseCase.Assets.Models;

namespace HomesEngland.Boundary.UseCase
{
    public interface IGetAssets : IUseCaseTask<GetAssetsRequest, GetAssetsResponse>
    {
        
    }
}