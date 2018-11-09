using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.SchemeID.MultipleResults
{
    public class SearchSchemeIDExactMatchMultipleResultsExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "57606864";

        protected override Asset[] AssetsInGateway => new[]
        {
            
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "57606864",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeId = "57606864",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Hut", 
                SchemeId = "571606864",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = "57606864",
                AccountingYear = "12123554"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "57606864",
                AccountingYear = "1234"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "571606864",
                AccountingYear = "1234"
            } 
            
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "57606864",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeId = "57606864",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = "57606864",
                AccountingYear = "12123554"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "57606864",
                AccountingYear = "1234"
            } 
        };
    }
}