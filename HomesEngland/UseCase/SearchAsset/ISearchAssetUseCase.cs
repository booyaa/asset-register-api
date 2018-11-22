using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.GetAsset
{
    public interface ISearchAssetUseCase : IAsyncUseCaseTask<SearchAssetRequest, SearchAssetResponse>
    {

    }
}
