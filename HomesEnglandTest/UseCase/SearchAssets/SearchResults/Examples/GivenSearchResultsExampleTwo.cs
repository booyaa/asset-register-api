using HomesEngland.Domain;

namespace HomesEnglandTest.UseCase.SearchAssets.SearchResults.Examples
{
    public class GivenSearchResultsExampleTwo:GivenSearchResults
    {
        protected override string SearchQuery => "Cats";
        protected override Asset[] GatewaySearchResults  => new[]
        {
            new Asset
            {
                Address = "Cow Hut",
                AccountingYear = "2001",
                SchemeId = "5467"
            },
            new Asset
            {
                Address = "Cow are ok also",
                AccountingYear = "1981",
                SchemeId = "888"
            }, 
            new Asset
            {
                Address = "2 The Street",
                AccountingYear = "2003",
                SchemeId = "13567"
            },
            new Asset
            {
                Address = "Canadian Geese are full of mean",
                AccountingYear = "001",
                SchemeId = "0"
            }
        };
    }
}