using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.SchemeID.SingleResult
{
    public class SearchSchemeIDExactMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "999";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "999",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeId = "912399",
                AccountingYear = "1234"
            },
            new Asset()
            {
                Address = "Clown", 
                SchemeId = "1213",
                AccountingYear = "9582"
            },
            new Asset()
            {
                Address = "Horse", 
                SchemeId = "12355",
                AccountingYear = "11234"
            }
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeId = "999",
                AccountingYear = "1254"
            }
        };
    }
}