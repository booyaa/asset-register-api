using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using Infrastructure.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApiTest.Controller.GetAsset
{
    using AssetDictionary = Dictionary<string, string>;

    [TestFixture]
    public abstract class GetAssetControllerTest
    {
        protected abstract int AssetId { get; }
        protected abstract string AssetAddress { get; }
        protected abstract string AssetSchemeID { get; }
        protected abstract string AssetAccountingYear { get; }
        private Mock<IGetAsset> _mock;
        private AssetController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAsset>();
            _mock.Setup(useCase => useCase.Execute(AssetId)).ReturnsAsync(() => (new Asset()
            {
                Address = AssetAddress,
                AccountingYear = int.Parse(AssetAccountingYear),
                SchemeId = int.Parse(AssetSchemeID)
            }).ToDictionary());

            _controller = new AssetController(_mock.Object);
        }

        [Test]
        public async Task GetAssetControllerCallsUseCase()
        {
            await _controller.Get(AssetId);
            _mock.Verify(mock => mock.Execute(AssetId), Times.Once());
        }

        [Test]
        public async Task GetAssetControllerReturnsJson()
        {
            ActionResult<ApiResponse<AssetDictionary>> returnedData = await _controller.Get(AssetId);
            AssetDictionary assetAsJson = returnedData.Value.Data;

            if(assetAsJson["Address"]!=null)
            {
                Assert.True(AssetAddress == assetAsJson["Address"]);
            }
            if(assetAsJson["SchemeID"]!=null)
            {
                Assert.True(AssetSchemeID == assetAsJson["SchemeID"]);
            }
            if(assetAsJson["AccountingYear"]!=null)
            {
                Assert.True(AssetAccountingYear == assetAsJson["AccountingYear"]);
            }
        }

    }
}
