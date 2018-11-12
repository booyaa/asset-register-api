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
        public AssetController _classUnderTest;
        public Mock<IGetAsset> _mockUseCase;
        public AssetControllerTests()
        {
            _mockUseCase = new Mock<IGetAsset>();
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
        public async Task GivenInValidRequest_ThenThrowsBadRequestException()
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetAssetRequest>())).Throws<BadRequestException>();
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async ()=> await _classUnderTest.Get(null));
        }
    }
}
