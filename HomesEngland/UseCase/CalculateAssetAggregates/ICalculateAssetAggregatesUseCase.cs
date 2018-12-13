using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.CalculateAssetAggregates.Models;

namespace HomesEngland.UseCase.CalculateAssetAggregates
{
    
    public interface ICalculateAssetAggregatesUseCase:IAsyncUseCaseTask<CalculateAssetAggregateRequest, CalculateAssetAggregateResponse>
    {

    }
}
