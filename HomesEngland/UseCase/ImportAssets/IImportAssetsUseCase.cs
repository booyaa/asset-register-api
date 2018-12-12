using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.ImportAssets.Models;

namespace HomesEngland.UseCase.ImportAssets
{
    public interface IImportAssetsUseCase:IAsyncUseCaseTask<ImportAssetsRequest, ImportAssetsResponse>
    {

    }
}
