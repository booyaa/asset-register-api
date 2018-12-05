using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.ImportAssets.Models;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.ImportAssets
{
    public class ImportAssetsUseCase : IImportAssetsUseCase
    {
        private readonly ICreateAssetUseCase _createAssetUseCase;
        private readonly ILogger<IImportAssetsUseCase> _logger;

        public ImportAssetsUseCase(ICreateAssetUseCase createAssetUseCase, ILogger<IImportAssetsUseCase> logger)
        {
            _createAssetUseCase = createAssetUseCase;
            _logger = logger;
        }

        public async Task<ImportAssetsResponse> ExecuteAsync(ImportAssetsRequest request, CancellationToken cancellationToken)
        {
            List<AssetOutputModel> importedAssets = new List<AssetOutputModel>();

            for (int i = 0; i < request?.AssetLines?.Count; i++)
            {
                var createAssetRequest = new CreateAssetRequest(request.AssetLines.ElementAt(0), request.Delimiter);
                var response = await _createAssetUseCase.ExecuteAsync(createAssetRequest, cancellationToken).ConfigureAwait(false);
                _logger.LogInformation($"Record: Imported {i} of {request?.AssetLines.Count}");
                importedAssets.Add(response?.Asset);
            }

            var importResponse = new ImportAssetsResponse
            {
                AssetsImported = importedAssets
            };
            return importResponse;
        }
    }
}
