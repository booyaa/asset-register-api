using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace AssetRegisterTests.HomesEngland.Controller.SearchAssets.NoAssets
{
    using AssetDictionary = Dictionary<string, string>;
    using AssetsDictionary = Dictionary<string, Dictionary<string, string>[]>;

    public class SearchAssetsControllerNoAssetsTest
    {
        private Mock<ISearchAssetsUseCase> _mock;
        private SearchController _controller;
        protected Asset[] SearchResults => new Asset[0];
        private string SearchQuery => "Search";

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ISearchAssetsUseCase>();
            _mock.Setup(useCase => useCase.Execute(SearchQuery)).ReturnsAsync(() => SearchResults.ToList().Select(_=>_.ToDictionary()).ToArray());
            _controller = new SearchController(_mock.Object);
        }

        [Test]
        public async Task ReturnsJsonWithEmptyAssetsArray()
        {
            ActionResult<AssetsDictionary> controllerResult = await  _controller.Get(SearchQuery);
            Assert.AreEqual(
                controllerResult.Value,
                new AssetsDictionary {
                    {"Assets", new AssetDictionary[0]}
                }
            );
        }


    }
}
