using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.SchemeID.MultipleResults
{
    public class SearchSchemeIDExactMatchMultipleResultsExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "55567";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "55567",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeId = "55567",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = "55567",
                AccountingYear = "12123554"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "67",
                AccountingYear = "1234"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "55567",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeId = "55567",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = "55567",
                AccountingYear = "12123554"
            },
        };
    }
}