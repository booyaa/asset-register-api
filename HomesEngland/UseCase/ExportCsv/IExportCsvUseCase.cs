using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase.ExportCsv.Models;

namespace HomesEngland.UseCase.ExportCsv
{
    public interface IExportCsvUseCase:IAsyncUseCaseTask<ExportCsvRequest, ExportCsvResponse>
    {

    }
}
