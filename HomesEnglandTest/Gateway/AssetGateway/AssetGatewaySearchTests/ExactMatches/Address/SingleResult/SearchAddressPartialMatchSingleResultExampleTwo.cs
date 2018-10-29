using HomesEngland.Domain;
using HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway;

namespace HomesEnglandTest.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.Address.SingleResult
{
    public class SearchAddressPartialMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "Do";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "999",
                AccountingYear = "1988"
            },
            new Asset()
            {
                Address = "Moomin", 
                SchemeID = "1004",
                AccountingYear = "1998"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "999",
                AccountingYear = "1988"
            } 
        };
    }
}