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
                SchemeID = "12354",
                AccountingYear = "11235066"
            },
            new Asset()
            {
                Address = "Lion", 
                SchemeID = "134",
                AccountingYear = "11214"
            },
            new Asset()
            {
                Address = "House", 
                SchemeID = "3",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "1234",
                AccountingYear = "1066"
            }
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "1234",
                AccountingYear = "1066"
            }
        };
    }
}