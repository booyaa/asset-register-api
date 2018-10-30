using System.Threading.Tasks;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Exception;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApiTest.Controller.GetAsset.NoAssets
{
    [TestFixture]
    public abstract class GetAssetControllerNoAssetsTest
    {
        protected abstract int AssetId { get; }
        private Mock<IGetAssetUseCase> _mock;
        private AssetController _controller;
        
        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetUseCase>();
            _mock.Setup(useCase => useCase.Execute(AssetId)).ReturnsAsync(() =>throw new NoAssetException());
            
            _controller = new AssetController(_mock.Object);
        }
        
        [Test]
        public async Task ReturnsEmptyJson()
        {
            var result = await _controller.Get(AssetId);
            Assert.AreEqual(result,"{}");
        }
    }
}