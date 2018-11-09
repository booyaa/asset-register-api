using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.AccountingYear.MultipleResults
{
    public class SearchAccountingYearPartialMatchMultipleResultsExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "982";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset
            {
                Address = "Cat", 
                SchemeId = 666,
                AccountingYear = 1982
            },
            new Asset
            {
                Address = "Dog", 
                SchemeId = 555,
                AccountingYear = 1882
            },
            new Asset
            {
                Address = "Pig", 
                SchemeId = 1234,
                AccountingYear = 1982
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset
            {
                Address = "Cat", 
                SchemeId = 666,
                AccountingYear = 1982
            },
            new Asset
            {
                Address = "Pig", 
                SchemeId = 1234,
                AccountingYear = 1982
            } 
        };
    }
}