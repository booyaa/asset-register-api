using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using NUnit.Framework;

namespace AssetRegisterTests.HomesEngland.AcceptanceTest
{   
    [TestFixture]
    public class GetAssetAcceptanceTest
    {
        private AssetRegister _application;
        private IGetAssetUseCase _getAssetUseCase;

        [SetUp]
        public void SetUp()
        {
            _application = new AssetRegister();
            _getAssetUseCase = _application.GetGetAssetUseCase();
        }

        private async Task<int> AddAsset(Asset asset)
        {
            return await _application._AssetGateway().AddAsset(asset);
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
            
            Dictionary<string, string> returnedDictionary = _getAssetUseCase.Execute(id).Result;
            
            Assert.True(asset.Address == returnedDictionary["Address"]);
            Assert.True(asset.AccountingYear == returnedDictionary["AccountingYear"]);
            Assert.True(asset.SchemeID == returnedDictionary["SchemeID"]);
        }
    }
}