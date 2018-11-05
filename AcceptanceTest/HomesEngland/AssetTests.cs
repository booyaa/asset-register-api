using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using NUnit.Framework;

namespace AssetRegisterTests.HomesEngland
{   
    [TestFixture]
    public class GetAssetAcceptanceTest
    {
        private AssetRegister _application;
        private IGetAsset _getAsset;
        private IGetAssets _getAssets;
        private ISearchAssets _searchAssets;

        [SetUp]
        public void SetUp()
        {
            _application = new AssetRegister();
            _getAsset = _application.Get<IGetAsset>();
            _getAssets = _application.Get<IGetAssets>();
            _searchAssets = _application.Get<ISearchAssets>();
        }

        private async Task<int> AddAsset(Asset asset)
        {
            return await _application._AssetGateway().AddAsset(asset);
        }
        
        private async Task<int[]> AddAssets(Asset[] assets)
        {
            return await Task.WhenAll(
                assets.Select(async asset => await _application._AssetGateway().AddAsset(asset)).ToList()
            );
        }

        private static List<(Dictionary<string, string>, Asset)> ZipActualWithExpected(
            Dictionary<string, string>[] actualAssets,
            Asset[] assets)
        {
            return actualAssets.Zip(
                assets,
                (actualAsset, expectedAsset) => (actualAsset, expectedAsset)
            ).ToList();
        }

        private void AssertResponseMatchesAsset((Dictionary<string, string>, Asset) testCase)
        {
            (var actual, var expected) = testCase;

            Assert.AreEqual(expected.Address, actual["Address"]);
            Assert.AreEqual(expected.AccountingYear, actual["AccountingYear"]);
            Assert.AreEqual(expected.SchemeID, actual["SchemeID"]);
        }

        [Test]
        public async Task GetExistingAsset()
        {
            Asset asset = new Asset
            {
                Address = "1, The Pavement, Town",
                SchemeID = "22",
                AccountingYear = "1999"

            };

            var id = await AddAsset(asset);
            
            Dictionary<string, string> returnedDictionary = _getAsset.Execute(id).Result;
            
            Assert.True(asset.Address == returnedDictionary["Address"]);
            Assert.True(asset.AccountingYear == returnedDictionary["AccountingYear"]);
            Assert.True(asset.SchemeID == returnedDictionary["SchemeID"]);
        }

        [Test]
        public async Task GetExistingAssets()
        {
            Asset[] assets =
            {
                new Asset
                {
                    Address = "1, The Pavement, Town",
                    SchemeID = "22",
                    AccountingYear = "1999"
                },
                new Asset
                {
                    Address = "2, The Dog, City",
                    SchemeID = "45",
                    AccountingYear = "1983"
                },
                new Asset
                {
                    Address = "Pavement",
                    SchemeID = "11",
                    AccountingYear = "1634"
                },
                new Asset
                {
                    Address = "Dog House",
                    SchemeID = "13",
                    AccountingYear = "1927"
                },
                new Asset
                {
                    Address = "Cat House",
                    SchemeID = "6345",
                    AccountingYear = "2229"
                },
                new Asset
                {
                    Address = "Bee Hive",
                    SchemeID = "234",
                    AccountingYear = "2018"
                }
            };

            int[] ids = await AddAssets(assets);

            var actualAssets = _getAssets.Execute(ids).Result;

            ZipActualWithExpected(actualAssets, assets)
                .ForEach(AssertResponseMatchesAsset);
        }

        [Test]
        public async Task SearchAssets()
        {
            Asset[] assets =
            {
                new Asset
                {
                    Address = "1, The Pavement, Town",
                    SchemeID = "22",
                    AccountingYear = "1999"
                },
                new Asset
                {
                    Address = "2, The Dog, City",
                    SchemeID = "45",
                    AccountingYear = "1983"
                },
                new Asset
                {
                    Address = "Pavement",
                    SchemeID = "11",
                    AccountingYear = "1983"
                },
                new Asset
                {
                    Address = "Dog House",
                    SchemeID = "13",
                    AccountingYear = "1927"
                },
                new Asset
                {
                    Address = "Cat House",
                    SchemeID = "6345",
                    AccountingYear = "2229"
                },
                new Asset
                {
                    Address = "Bee Hive",
                    SchemeID = "234",
                    AccountingYear = "2018"
                }
            };
           
            await AddAssets(assets);

            var searchResult = await _searchAssets.Execute("Cat");

            Assert.AreEqual(searchResult[0]["Address"], "Cat House");
            Assert.AreEqual(searchResult[0]["SchemeID"], "6345");
            Assert.AreEqual(searchResult[0]["AccountingYear"], "2229");

            searchResult = await _searchAssets.Execute("234");

            Assert.AreEqual(searchResult[0]["Address"], "Bee Hive");
            Assert.AreEqual(searchResult[0]["SchemeID"], "234");
            Assert.AreEqual(searchResult[0]["AccountingYear"], "2018");

            searchResult = await _searchAssets.Execute("1983");
            Assert.AreEqual(2, searchResult.Length);
        }
    }
}