using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets.Models;
using HomesEngland.UseCase.GetAsset.Models;
using Infrastructure.Api.Exceptions;
using Infrastructure.Api.Response.Validation;
using Microsoft.Extensions.Logging;

namespace HomesEngland.UseCase.GenerateAssets
{
    public class ConsoleAssetGenerator : IConsoleGenerator
    {
        private readonly IInputParser _inputParser;
        private readonly IGenerateAssetsUseCase _generateAssetUseCase;
        private readonly ILogger<ConsoleAssetGenerator> _logger;

        public ConsoleAssetGenerator(IInputParser inputParser, IGenerateAssetsUseCase generateAssetUseCase, ILogger<ConsoleAssetGenerator> logger)
        {
            _inputParser = inputParser;
            _generateAssetUseCase = generateAssetUseCase;
            _logger = logger;
        }

        public async Task<IList<AssetOutputModel>> ProcessAsync(string[] args)
        {
            IList<AssetOutputModel> output = null;
            PrintHelper();
            try
            {
                var request = ValidateInput(args);

                var cancellationTokenSource = new CancellationTokenSource();

                var generatedRecords = await _generateAssetUseCase.ExecuteAsync(request, cancellationTokenSource.Token).ConfigureAwait(false);

                Console.WriteLine($"Generated: {generatedRecords.RecordsGenerated.Count} records");

                output = generatedRecords?.RecordsGenerated;
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error,ex, ex.Message);
            }

            return output;
        }

        private GenerateAssetsRequest ValidateInput(string[] args)
        {
            if (args == null)
            {
                _logger.Log(LogLevel.Information, "Please enter input '--records {numberOfRecordsToGenerate}'");
                throw new ArgumentNullException(nameof(args));
            }

            var request = _inputParser.Parse(args);
            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                HandleProcessingFailure(validationResponse);
            return request;
        }

        private void PrintHelper()
        {
            _logger.Log(LogLevel.Information, "Welcome to the Asset Test Data Generator");
            _logger.Log(LogLevel.Information, "To generate assets please input:");
            _logger.Log(LogLevel.Information, "'--records {numberOfRecords}'");
        }

        private void HandleProcessingFailure(RequestValidationResponse validationResponse)
        {
            foreach (var error in validationResponse.ValidationErrors)
            {
                Console.WriteLine($"FieldName: {error?.FieldName}");
                Console.WriteLine($"Message: {error?.Message}");
            }
            throw new BadRequestException(validationResponse);
        }
    }
}
