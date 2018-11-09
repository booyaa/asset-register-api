using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.Address.MultipleResults
{
    public class SearchAddressPartialMatchMultipleResultsExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "ow";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeId = 22,
                AccountingYear = 1982
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = 11234,
                AccountingYear = 11235
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = 67,
                AccountingYear = 0
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeId = 22,
                AccountingYear = 1982
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = 11234,
                AccountingYear = 11235
            }, 
        };
    }
}