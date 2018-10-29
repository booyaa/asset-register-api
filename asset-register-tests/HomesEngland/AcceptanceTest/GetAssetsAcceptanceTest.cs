using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.UseCase;
using asset_register_api.Interface.UseCase;
using hear_api.HomesEngland.Gateway;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.AcceptanceTest
{   
    [TestFixture]
    public class GetAssetsAcceptanceTest
    {

        [Test]
        public async Task GetExistingAsset()
        {
            InMemoryAssetGateway gateway = new InMemoryAssetGateway();

            Asset[] assets =
            {
                new Asset()
                {
                    Address = "1, The Pavement, Town",
                    SchemeID = "22",
                    AccountingYear = "1999"

                },
                new Asset()
                {
                    Address = "2, The Dog, City",
                    SchemeID = "45",
                    AccountingYear = "1983"

                },
                new Asset()
                {
                    Address = "Pavement",
                    SchemeID = "11",
                    AccountingYear = "1634"

                },
                new Asset()
                {
                    Address = "Dog House",
                    SchemeID = "13",
                    AccountingYear = "1927"

                },
                 new Asset()
                {
                    Address = "Cat House",
                    SchemeID = "6345",
                    AccountingYear = "2229"

                },
                new Asset()
                {
                    Address = "Bee Hive",
                    SchemeID = "234",
                    AccountingYear = "2018"
                },
            };
         
            List<int> ids = new List<int>();
            for (int i = 0; i < assets.Length; i++)
            {  
                // Add Asset
                ids.Add(await gateway.AddAsset(assets[i]));
            }
            
            IGetAssetsUseCase getAssetsUseCase = new GetAssets(gateway);
            Dictionary<string, string>[] returnedValues =  getAssetsUseCase.Execute(ids.ToArray()).Result;

            for (int i = 0; i < returnedValues.Length; i++)
            {
                var assetAsDictionary = returnedValues[i]; 
                Assert.True(assets[i].Address == assetAsDictionary["Address"]);
                Assert.True(assets[i].AccountingYear == assetAsDictionary["AccountingYear"]);
                Assert.True(assets[i].SchemeID == assetAsDictionary["SchemeID"]);
            }
        }
    }
    
}