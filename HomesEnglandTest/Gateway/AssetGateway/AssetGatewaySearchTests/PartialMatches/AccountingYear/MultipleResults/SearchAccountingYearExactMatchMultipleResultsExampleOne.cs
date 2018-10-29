using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.PartialMatches.AccountingYear.MultipleResults
{
    public class SearchAccountingYearExactMatchMultipleResultsExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "1982";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "1234",
                AccountingYear = "1982"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "1234",
                AccountingYear = "1982"
            } 
        };
    }
}