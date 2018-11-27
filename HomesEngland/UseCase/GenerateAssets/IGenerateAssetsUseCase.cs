using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.GenerateAssets.Models;

namespace HomesEngland.UseCase.GenerateAssets
{
    public interface IGenerateAssetsUseCase:IAsyncUseCaseTask<GenerateAssetsRequest, GenerateAssetsResponse>
    {

    }
}
