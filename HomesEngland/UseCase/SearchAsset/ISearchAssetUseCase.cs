using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.SearchAsset.Models;

namespace HomesEngland.UseCase.SearchAsset
{
    public interface ISearchAssetUseCase : IAsyncUseCaseTask<SearchAssetRequest, SearchAssetResponse>
    {

    }
}
