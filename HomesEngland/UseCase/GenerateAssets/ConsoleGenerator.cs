using System;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.GenerateAssets
{
    public class ConsoleGenerator : IConsoleGenerator
    {
        private readonly IInputParser _inputParser;
        private readonly IGenerateAssetsUseCase _generateAssetUseCase;

        public ConsoleGenerator(IInputParser inputParser, IGenerateAssetsUseCase generateAssetUseCase)
        {
            _inputParser = inputParser;
            _generateAssetUseCase = generateAssetUseCase;
        }

        public async Task ProcessAsync(string[] args)
        {
            PrintHelper();
            try
            {
                var request = await ValidateInput(args).ConfigureAwait(false);

                var cancellationTokenSource = new CancellationTokenSource();

                await _generateAssetUseCase.ExecuteAsync(request, cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task<GenerateAssetsRequest> ValidateInput(string[] args)
        {
            if (args == null)
                HandleProcessingFailure("Please enter input '--records {numberOfRecordsToGenerate}'");

            var request = _inputParser.Parse(args);
            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                HandleProcessingFailure(validationResponse);
            return request;
        }

        private void PrintHelper()
        {
            Console.WriteLine("Welcome to the Asset Test Data Generator");
            Console.WriteLine("To generate assets please input:");
            Console.WriteLine("'--records {numberOfRecords}'");
        }

        private void HandleProcessingFailure(string message)
        {
            Console.WriteLine(message);
            StopProcessing();
        }

        private void HandleProcessingFailure(RequestValidationResponse validationResponse)
        {
            foreach (var error in validationResponse.ValidationErrors)
            {
                Console.WriteLine($"FieldName: {error?.FieldName}");
                Console.WriteLine($"Message: {error?.Message}");
            }
            StopProcessing();
        }

        private void StopProcessing()
        {
            throw new GenerateAssetsException();
        }
    }
}
