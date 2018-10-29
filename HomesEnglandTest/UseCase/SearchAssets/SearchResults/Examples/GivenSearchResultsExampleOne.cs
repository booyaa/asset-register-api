using HomesEngland.Domain;

namespace HomesEnglandTest.UseCase.SearchAssets.SearchResults.Examples
{
    public class GivenSearchResultsExampleOne:GivenSearchResults
    {
        protected override string SearchQuery => "Dogs";
        protected override Asset[] GatewaySearchResults  => new[]
        {
            new Asset
            {
                Address = "Dogs House",
                AccountingYear = "1999",
                SchemeID = "1334"
            },
            new Asset
            {
                Address = "Dogs are ok",
                AccountingYear = "1982",
                SchemeID = "1337"
            }, 
        };

    }
}