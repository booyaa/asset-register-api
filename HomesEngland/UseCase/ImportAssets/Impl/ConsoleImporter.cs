using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.ImportAssets.Models;
using HomesEngland.UseCase.Models;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.ImportAssets.Impl
{
    public class ConsoleImporter : IConsoleImporter
    {
        private readonly IImportAssetsUseCase _importAssetsUseCase;
        private readonly IInputParser<ImportAssetConsoleInput> _inputParser;
        private readonly IFileReader<string> _fileReader;
        private readonly ILogger<IConsoleImporter> _logger;

        public ConsoleImporter(IImportAssetsUseCase importAssetsUseCase, IInputParser<ImportAssetConsoleInput> inputParser,IFileReader<string> fileReader, ILogger<IConsoleImporter> logger)
        {
            _importAssetsUseCase = importAssetsUseCase;
            _inputParser = inputParser;
            _fileReader = fileReader;
            _logger = logger;
        }

        public async Task<IList<AssetOutputModel>> ProcessAsync(string[] args)
        {
            ValidateConsoleInput(args);
            var parsedInput = _inputParser.Parse(args);
            
            var cancellationTokenSource = new CancellationTokenSource();

            var text = await _fileReader.ReadAsync(parsedInput.FilePath, cancellationTokenSource.Token).ConfigureAwait(false);

            var importAssetsRequest = new ImportAssetsRequest
            {
                Delimiter = parsedInput.Delimiter,
                //AssetLines = text?.Split("\n")
            };

            await _importAssetsUseCase.ExecuteAsync(importAssetsRequest, cancellationTokenSource.Token).ConfigureAwait(false);

            return null;
        }

        private void ValidateConsoleInput(string[] args)
        {
            if (args == null)
            {
                _logger.Log(LogLevel.Information, "Please enter input '--file {absolutePathToFile} --delimiter {delimiter}'");
                throw new ArgumentNullException(nameof(args));
            }
        }
    }
}
