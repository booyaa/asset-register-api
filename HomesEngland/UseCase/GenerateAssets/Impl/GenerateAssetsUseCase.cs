using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GenerateAssets.Models;
using HomesEngland.UseCase.GetAsset.Models;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.UseCase.GenerateAssets.Impl
{
    public class GenerateAssetsUseCase:IGenerateAssetsUseCase
    {
        private readonly ICreateAssetUseCase _createAssetUseCase;

        public GenerateAssetsUseCase(ICreateAssetUseCase createAssetUseCase)
        {
            _createAssetUseCase = createAssetUseCase;
        }

        public async Task<GenerateAssetsResponse> ExecuteAsync(GenerateAssetsRequest request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            IList<AssetOutputModel> createdList = new List<AssetOutputModel>();

            for (int i = 0; i < request.Records; i++)
            {
                var createAssetRequest = GenerateCreateAssetRequest();
                var response = await _createAssetUseCase.ExecuteAsync(createAssetRequest, cancellationToken).ConfigureAwait(false);
                createdList.Add(response?.Asset);
            }

            var generateAssetsResponse = new GenerateAssetsResponse
            {
                RecordsGenerated = createdList
            };
            return generateAssetsResponse;
        }

        private CreateAssetRequest GenerateCreateAssetRequest()
        {
            var random = new Random(0);
            var faker = new Faker("en");
            var completionDateForHpiStart = faker.Date.Soon(random.Next(1, 15));
            var imsActualCompletionDate = faker.Date.Soon(random.Next(30, 90));
            var imsExpectedCompletionDate = faker.Date.Soon(random.Next(15, 90));
            var hopCompletionDate = faker.Date.Soon(random.Next(15, 90));
            var differenceFromImsExpectedCompletionToHopCompletionDate =
                (imsExpectedCompletionDate.Date - hopCompletionDate).Days;
            var request = new Faker<CreateAssetRequest>()
                .RuleFor(property => property.AccountingYear, (fake, model) => random.Next(2018, 2020).ToString())
                .RuleFor(property => property.Address, (fake, model) => fake.Address.FullAddress())
                .RuleFor(property => property.NoOfBeds, (fake, model) => fake.Random.Int(1, 4).ToString())
                .RuleFor(property => property.NoOfBeds, (fake, model) => fake.Random.Int(1, 4).ToString())
                .RuleFor(property => property.DevelopingRslName, (fake, model) => fake.Company.CompanyName())
                .RuleFor(property => property.LocationLaRegionName, (fake, model) => fake.Address.County())
                .RuleFor(property => property.ImsOldRegion, (fake, model) => fake.Address.County())
                .RuleFor(property => property.MonthPaid, (fake, model) => fake.Date.Month())
                .RuleFor(property => property.SchemeId, (fake, model) => random.Next(1000, 2147483647))
                .RuleFor(property => property.AgencyEquityLoan,
                    (fake, model) => fake.Finance.Amount(5000m, 100000m))
                .RuleFor(property => property.CompletionDateForHpiStart, (fake, model) => completionDateForHpiStart)
                .RuleFor(property => property.ImsActualCompletionDate, (fake, model) => imsActualCompletionDate)
                .RuleFor(property => property.ImsExpectedCompletionDate, (fake, model) => imsExpectedCompletionDate)
                .RuleFor(property => property.ImsLegalCompletionDate,
                    (fake, model) => fake.Date.Soon(random.Next(15, 90)))
                .RuleFor(property => property.HopCompletionDate, (fake, model) => hopCompletionDate)
                .RuleFor(property => property.DifferenceFromImsExpectedCompletionToHopCompletionDate,
                    (fake, model) => differenceFromImsExpectedCompletionToHopCompletionDate)
                .RuleFor(property => property.DeveloperEquityLoan, (fake, model) => null)
                .RuleFor(property => property.ShareOfRestrictedEquity,
                    (fake, model) => fake.Finance.Amount(50, 100))
                .RuleFor(property => property.Deposit,
                (fake, model) => fake.Finance.Amount(5000, 100000));

            return request;
        }

        private void ValidateRequest(GenerateAssetsRequest request)
        {
            if (request == null)
                throw new BadRequestException();

            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);
        }
    }
}
