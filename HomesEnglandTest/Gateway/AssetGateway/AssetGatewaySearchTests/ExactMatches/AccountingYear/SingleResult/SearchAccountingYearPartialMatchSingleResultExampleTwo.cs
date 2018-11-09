using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.AccountingYear.SingleResult
{
    public class SearchAccountingYearPartialMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "106";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Duck", 
                SchemeId = 222,
                AccountingYear = 1066
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeId = 555,
                AccountingYear = 1556
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
                Address = "Duck", 
                SchemeId = 222,
                AccountingYear = 1066
            } 
        };
    }
}