using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.AccountingYear.MultipleResults
{
    public class SearchAccountingYearExactMatchMultipleResultsExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "1066";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Sheep", 
                SchemeId = "12354",
                AccountingYear = "11235066"
            },
            new Asset()
            {
                Address = "Lion", 
                SchemeId = "134",
                AccountingYear = "11214"
            },
            new Asset()
            {
                Address = "House", 
                SchemeId = "3",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Cat", 
                SchemeId = "666",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeId = "555",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "1234",
                AccountingYear = "1066"
            }
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeId = "666",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeId = "555",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "1234",
                AccountingYear = "1066"
            }
        };
    }
}