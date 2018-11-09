using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.AccountingYear.SingleResult
{
    public class SearchAccountingYearPartialMatchSingleResultExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "982";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeId = 666,
                AccountingYear = 1982
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeId = 555,
                AccountingYear = 1556
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeId = 666,
                AccountingYear = 1982
            } 
        };
    }
}