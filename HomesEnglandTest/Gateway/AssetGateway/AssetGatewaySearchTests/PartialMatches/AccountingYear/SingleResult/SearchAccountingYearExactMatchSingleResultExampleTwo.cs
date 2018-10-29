using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.AccountingYear.SingleResult
{
    public class SearchAccountingYearExactMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "1066";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Duck", 
                SchemeID = "222",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "555",
                AccountingYear = "1556"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1556"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Duck", 
                SchemeID = "222",
                AccountingYear = "1066"
            } 
        };
    }
}