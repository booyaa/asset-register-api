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
                SchemeID = "55567",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeID = "55567",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "55567",
                AccountingYear = "12123554"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "67",
                AccountingYear = "1234"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "55567",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeID = "55567",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "55567",
                AccountingYear = "12123554"
            },
        };
    }
}