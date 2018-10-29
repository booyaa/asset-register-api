using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace AssetRegisterTests.HomesEngland.Controller.GetAssets.NoAssets
{
    [TestFixture]
    public class GetAssetsControllerNoAssetsTest
    {

        private int[] AssetIds = {1, 2, 3, 4};
        private Mock<IGetAssetsUseCase> _mock;
        private AssetsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetsUseCase>();
            _mock.Setup(useCase => useCase.Execute(AssetIds)).ReturnsAsync(
                () => new Dictionary<string, string>[0]);
            _controller = new AssetsController(_mock.Object);
        }

        [Test]
        public async Task ReturnsJsonWithEmptyAssetsArray()
        {
            ActionResult<string> controllerResult = await  _controller.Get(AssetIds);
            Assert.AreEqual(controllerResult.Value, "{\"Assets\":[]}");
        }
    }
}
