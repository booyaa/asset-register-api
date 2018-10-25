using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.Address
{
    public class SearchAddressPartialMatchSingleResultExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "ow";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "22",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "67",
                AccountingYear = "0"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "22",
                AccountingYear = "1982"
            } 
        };
    }
}