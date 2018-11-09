using HomesEngland.Domain;

namespace WebApiTest.Controller.SearchAssets.Examples
{
    public class SearchAssetsControllerTestExampleTwo:SearchAssetsControllerTest
    {
        protected override Asset[] SearchResults => new Asset[]
        {
            new Asset()
            {
                Address = "Dog House",
                AccountingYear = "1235",
                SchemeId = "234"
            },
            new Asset()
            {
                Address = "Hall",
                AccountingYear = "1211135",
                SchemeId = "223434"
            },
            new Asset()
            {
                Address = "Cat",
                AccountingYear = "1234677777",
                SchemeId = "1235723424"
            },
        };
     
    }
}