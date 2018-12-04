using System.Threading.Tasks;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Models;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;
using FluentAssertions;
using Infrastructure.Api.Exceptions;

namespace WebApiTest.Controller.Asset.Get
{
    [TestFixture]
    public class AssetControllerTests
    {
        private readonly AssetController _classUnderTest;
        private readonly Mock<IGetAssetUseCase> _mockUseCase;
        public AssetControllerTests()
        {
            _mockUseCase = new Mock<IGetAssetUseCase>();
            _classUnderTest = new AssetController(_mockUseCase.Object);
        }

        [Test]
        public async Task GivenValidRequest_ThenReturnsGetAssetResponse()
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetAssetRequest>())).ReturnsAsync(new GetAssetResponse());
            var request = new GetAssetRequest();
            //act
            var response = await _classUnderTest.Get(request);
            //assert
            response.Should().NotBeNull();
        }

        [Test]
        public void GivenInValidRequest_ThenThrowsBadRequestException()
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetAssetRequest>())).Throws<BadRequestException>();
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async ()=> await _classUnderTest.Get(null));
        }
    }
}
