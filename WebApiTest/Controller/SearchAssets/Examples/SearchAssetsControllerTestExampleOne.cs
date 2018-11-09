using HomesEngland.Domain;

namespace WebApiTest.Controller.SearchAssets.Examples
{
    public class SearchAssetsControllerTestExampleOne:SearchAssetsControllerTest
    {
        protected override Asset[] SearchResults => new Asset[]
        {
            new Asset()
            {
                Address = "Cow Yard",
                AccountingYear = "1998",
                SchemeId = "666"
            }, 
        };
     
    }
}