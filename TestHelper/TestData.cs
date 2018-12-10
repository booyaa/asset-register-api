using System;
using Bogus;
using HomesEngland.Gateway;
using HomesEngland.UseCase.CreateAsset.Models;

namespace TestHelper
{
    public static class TestData
    {
        public static class Domain
        {
            public static DapperAsset GenerateAsset()
            {
                var random = new Random(0);

                var faker = new Faker("en");
                var completionDateForHpiStart = faker.Date.Soon(random.Next(1, 15));
                var imsActualCompletionDate = faker.Date.Soon(random.Next(30, 90));
                var imsExpectedCompletionDate = faker.Date.Soon(random.Next(15, 90));
                var hopCompletionDate = faker.Date.Soon(random.Next(15, 90));
                var differenceFromImsExpectedCompletionToHopCompletionDate =
                    (imsExpectedCompletionDate.Date - hopCompletionDate).Days;

                var asset = new Faker<DapperAsset>("en")
                        
                        .RuleFor(property => property.Address, (fake, model) => fake.Address.FullAddress())
                        .RuleFor(property => property.NoOfBeds, (fake, model) => fake.Random.Int(1, 4))
                        
                        .RuleFor(property => property.DevelopingRslName, (fake, model) => fake.Company.CompanyName())
                        .RuleFor(property => property.LocationLaRegionName, (fake, model) => fake.Address.County())
                        .RuleFor(property => property.ImsOldRegion, (fake, model) => fake.Address.County())
                        
                        .RuleFor(property => property.SchemeId, (fake, model) => fake.IndexGlobal)
                        .RuleFor(property => property.AgencyEquityLoan,
                            (fake, model) => fake.Finance.Amount(5000m, 100000m))
                        .RuleFor(property => property.CompletionDateForHpiStart,
                            (fake, model) => completionDateForHpiStart)
                        .RuleFor(property => property.ImsActualCompletionDate, (fake, model) => imsActualCompletionDate)
                        .RuleFor(property => property.ImsExpectedCompletionDate,
                            (fake, model) => imsExpectedCompletionDate)
                        .RuleFor(property => property.ImsLegalCompletionDate,
                            (fake, model) => fake.Date.Soon(random.Next(15, 90)))
                        .RuleFor(property => property.HopCompletionDate, (fake, model) => hopCompletionDate)
                        .RuleFor(property => property.DeveloperEquityLoan, (fake, model) => null)
                        .RuleFor(property => property.ShareOfRestrictedEquity,
                            (fake, model) => fake.Finance.Amount(50, 100))
                    ;
                return asset;
            }
        }

        public static class UseCase
        {
            public static CreateAssetRequest GenerateCreateAssetRequest()
            {
                var random = new Random();
                var faker = new Faker("en");
                var completionDateForHpiStart = faker.Date.Soon(random.Next(1, 15));
                var imsActualCompletionDate = faker.Date.Soon(random.Next(30, 90));
                var imsExpectedCompletionDate = faker.Date.Soon(random.Next(15, 90));
                var hopCompletionDate = faker.Date.Soon(random.Next(15, 90));
                var differenceFromImsExpectedCompletionToHopCompletionDate =
                    (imsExpectedCompletionDate.Date - hopCompletionDate).Days;
                var request = new Faker<CreateAssetRequest>()
                    
                    .RuleFor(property => property.Address, (fake, model) => fake.Address.FullAddress())
                    .RuleFor(property => property.NoOfBeds, (fake, model) => fake.Random.Int(1, 4))
                    .RuleFor(property => property.DevelopingRslName, (fake, model) => fake.Company.CompanyName())
                    .RuleFor(property => property.LocationLaRegionName, (fake, model) => fake.Address.County())
                    .RuleFor(property => property.ImsOldRegion, (fake, model) => fake.Address.County())
                    
                    .RuleFor(property => property.SchemeId, (fake, model) => fake.IndexGlobal)
                    .RuleFor(property => property.AgencyEquityLoan,
                        (fake, model) => fake.Finance.Amount(5000m, 100000m))
                    .RuleFor(property => property.CompletionDateForHpiStart, (fake, model) => completionDateForHpiStart)
                    .RuleFor(property => property.ImsActualCompletionDate, (fake, model) => imsActualCompletionDate)
                    .RuleFor(property => property.ImsExpectedCompletionDate, (fake, model) => imsExpectedCompletionDate)
                    .RuleFor(property => property.ImsLegalCompletionDate,
                        (fake, model) => fake.Date.Soon(random.Next(15, 90)))
                    .RuleFor(property => property.HopCompletionDate, (fake, model) => hopCompletionDate)
                    
                        
                    .RuleFor(property => property.DeveloperEquityLoan, (fake, model) => null)
                    .RuleFor(property => property.ShareOfRestrictedEquity,
                        (fake, model) => fake.Finance.Amount(50, 100));

                return request;
            }
        }
    }
}
