using System;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.ExportCsv.Models;

namespace HomesEngland.UseCase.ExportCsv
{

    public class ExportCsvUseCase:IExportCsvUseCase
    {
        public Task<ExportCsvResponse> ExecuteAsync(ExportCsvRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
