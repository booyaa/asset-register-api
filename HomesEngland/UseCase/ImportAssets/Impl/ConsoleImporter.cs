using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.ImportAssets.Models;
using Infrastructure.Api.Exceptions;
using Infrastructure.Api.Response.Validation;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.ImportAssets.Impl
{
    public class ConsoleImporter : IConsoleImporter
    {
        private readonly IImportAssetsUseCase _importAssetsUseCase;
        private readonly IInputParser<ImportAssetsRequest> _inputParser;
        private readonly ILogger<IConsoleImporter> _logger;

        public ConsoleImporter(IImportAssetsUseCase importAssetsUseCase, IInputParser<ImportAssetsRequest> inputParser, ILogger<IConsoleImporter> logger)
        {
            _importAssetsUseCase = importAssetsUseCase;
            _inputParser = inputParser;
            _logger = logger;
        }

        public async Task<IList<AssetOutputModel>> ProcessAsync(string[] args)
        {
            var importAssetsRequest = ValidateInput(args);



            await _importAssetsUseCase.ExecuteAsync(importAssetsRequest, CancellationToken.None).ConfigureAwait(false);

            return null;
        }

        private ImportAssetsRequest ValidateInput(string[] args)
        {
            if (args == null)
            {
                _logger.Log(LogLevel.Information, "Please enter input '--file {absolutePathToFile} --delimiter {delimiter}'");
                throw new ArgumentNullException(nameof(args));
            }

            var request = _inputParser.Parse(args);
            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                HandleProcessingFailure(validationResponse);
            return request;
        }

        private void HandleProcessingFailure(RequestValidationResponse validationResponse)
        {
            foreach (var error in validationResponse.ValidationErrors)
            {
                _logger.Log(LogLevel.Information, $"FieldName: {error?.FieldName}");
                _logger.Log(LogLevel.Information, $"Message: {error?.Message}");
            }
            throw new BadRequestException(validationResponse);
        }
    }
}
