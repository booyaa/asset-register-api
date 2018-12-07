using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateAsset.Models.Factory;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.ImportAssets.Models;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.ImportAssets.Impl
{
    public class ImportAssetsUseCase : IImportAssetsUseCase
    {
        private readonly ICreateAssetUseCase _createAssetUseCase;
        private readonly IFactory<CreateAssetRequest, CsvAsset> _createAssetFactory;
        private readonly ILogger<IImportAssetsUseCase> _logger;

        public ImportAssetsUseCase(ICreateAssetUseCase createAssetUseCase, IFactory<CreateAssetRequest, CsvAsset> createAssetFactory,ILogger<IImportAssetsUseCase> logger)
        {
            _createAssetUseCase = createAssetUseCase;
            _createAssetFactory = createAssetFactory;
            _logger = logger;
        }

        public async Task<ImportAssetsResponse> ExecuteAsync(ImportAssetsRequest request, CancellationToken cancellationToken)
        {
            var importedAssets = await ImportAssets(request, cancellationToken);

            var importResponse = new ImportAssetsResponse
            {
                AssetsImported = importedAssets
            };
            return importResponse;
        }

        private async Task<IList<AssetOutputModel>> ImportAssets(ImportAssetsRequest request, CancellationToken cancellationToken)
        {
            IList<AssetOutputModel> importedAssets = new List<AssetOutputModel>();
            for (int i = 0; i < request?.AssetLines?.Count; i++)
            {
                var createAssetRequest = CreateAssetRequest(request, i);

                var response = await _createAssetUseCase.ExecuteAsync(createAssetRequest, cancellationToken).ConfigureAwait(false);

                _logger.LogInformation($"Record: Imported {i} of {request?.AssetLines.Count}");
                importedAssets.Add(response?.Asset);
            }

            return importedAssets;
        }

        private CreateAssetRequest CreateAssetRequest(ImportAssetsRequest request, int i)
        {
            var csvAsset = new CsvAsset
            {
                Delimiter = request.Delimiter,
                CsvLine = request.AssetLines.ElementAtOrDefault(i)
            };
            var createAssetRequest = _createAssetFactory.Create(csvAsset);
            return createAssetRequest;
        }
    }
}
