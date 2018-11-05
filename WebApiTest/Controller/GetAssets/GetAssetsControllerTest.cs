using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApiTest.Controller.GetAssets
{
    using AssetDictionary = Dictionary<string, string>;
    using AssetsDictionary = Dictionary<string, Dictionary<string, string>[]>;

    [TestFixture]
    public abstract class GetAssetsControllerTest
    {
        protected abstract Asset[] Assets { get; }
        protected abstract int[] AssetIds { get; }

        private Mock<IGetAssets> _mock;
        private AssetsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssets>();
            _mock.Setup(useCase => useCase.Execute(AssetIds)).ReturnsAsync(
                () => Assets.Select(_ => _.ToDictionary()).ToArray());

            _controller = new AssetsController(_mock.Object);
        }

        [Test]
        public async Task GetAssetControllerCallsUseCase()
        {
            await _controller.Get(AssetIds);
            _mock.Verify(mock => mock.Execute(AssetIds), Times.Once());
        }

        [Test]
        public async Task GetAssetControllerReturnsJson()
        {
            ActionResult<AssetsDictionary> returnedData = await _controller.Get(AssetIds);
            AssetsDictionary json = returnedData.Value;
            foreach (AssetDictionary assetAsJson in json["Assets"])
            {
                if(assetAsJson["Address"]!=null)
                {
                    Assert.True(Assets.Any(_=>_.Address == assetAsJson["Address"]));
                }
                if(assetAsJson["SchemeID"]!=null)
                {
                    Assert.True(Assets.Any(_=>_.SchemeID == assetAsJson["SchemeID"]));
                }
                if(assetAsJson["AccountingYear"]!=null)
                {
                    Assert.True(Assets.Any(_=>_.AccountingYear == assetAsJson["AccountingYear"]));
                }
            }
        }

        protected Asset GetAsset(string address, string schemeID, string accountingYear)
        {
            return new Asset()
            {
                Address = address,
                SchemeID = schemeID,
                AccountingYear = accountingYear
            };
        }
    }
}
