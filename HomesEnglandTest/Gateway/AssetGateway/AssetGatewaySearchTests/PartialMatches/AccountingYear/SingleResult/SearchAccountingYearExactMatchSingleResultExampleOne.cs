using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.AccountingYear.SingleResult
{
    public class SearchAccountingYearExactMatchSingleResultExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "1982";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeId = "666",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeId = "555",
                AccountingYear = "1556"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeId = "666",
                AccountingYear = "1982"
            } 
        };
    }
}