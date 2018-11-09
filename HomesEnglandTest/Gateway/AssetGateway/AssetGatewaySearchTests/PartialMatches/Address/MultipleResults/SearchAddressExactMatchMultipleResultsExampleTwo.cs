using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.Address.MultipleResults
{
    public class SearchAddressExactMatchMultipleResultsExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "Clanger";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeId = "22",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "12355",
                AccountingYear = "665"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "67",
                AccountingYear = "0"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "12345",
                AccountingYear = "61165"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "2345",
                AccountingYear = "1234"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "12355",
                AccountingYear = "665"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "67",
                AccountingYear = "0"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "12345",
                AccountingYear = "61165"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "2345",
                AccountingYear = "1234"
            }  
        };
    }
}