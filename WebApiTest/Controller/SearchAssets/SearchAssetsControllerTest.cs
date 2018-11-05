using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApiTest.Controller.SearchAssets
{
    using AssetDictionary = Dictionary<string, string>;
    using AssetsDictionary = Dictionary<string, Dictionary<string, string>[]>;

    public abstract class SearchAssetsControllerTest
    {
        private Mock<ISearchAssets> _mock;
        private SearchController _controller;
        protected abstract Asset[] SearchResults { get; }
        private string SearchQuery => "Search";

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ISearchAssets>();
            _mock.Setup(useCase => useCase.Execute(SearchQuery)).ReturnsAsync(() => SearchResults.ToList().Select(_=>_.ToDictionary()).ToArray());
            _controller = new SearchController(_mock.Object);
        }

        [Test]
        public async Task SearchAssetControllerCallsUseCase()
        {
            await _controller.Get(SearchQuery);
            _mock.Verify(mock => mock.Execute(SearchQuery), Times.Once());
        }

        [Test]
        public async Task GetAssetControllerReturnsJson()
        {
            ActionResult<AssetsDictionary> returnedData = await _controller.Get(SearchQuery);
            AssetsDictionary json = returnedData.Value;
            foreach (AssetDictionary assetAsJson in json["Assets"])
            {
                if(assetAsJson["Address"]!=null)
                {
                    Assert.True(SearchResults.Any(_=>_.Address == assetAsJson["Address"]));
                }
                if(assetAsJson["SchemeID"]!=null)
                {
                    Assert.True(SearchResults.Any(_=>_.SchemeID == assetAsJson["SchemeID"]));
                }
                if(assetAsJson["AccountingYear"]!=null)
                {
                    Assert.True(SearchResults.Any(_=>_.AccountingYear == assetAsJson["AccountingYear"]));
                }
            }
        }
    }
}
