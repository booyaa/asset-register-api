using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.SearchAsset;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Exceptions;
using Moq;
using NUnit.Framework;
using WebApi.Controllers.Search;

namespace WebApiTest.Controller.Asset.Search
{
    [TestFixture]
    public class SearchAssetControllerTests
    {
        private readonly SearchAssetController _classUnderTest;
        private readonly Mock<ISearchAssetUseCase> _mockUseCase;
        public SearchAssetControllerTests()
        {
            _mockUseCase = new Mock<ISearchAssetUseCase>();
            _classUnderTest = new SearchAssetController(_mockUseCase.Object);
        }

        [Test]
        public async Task GivenValidRequest_ThenReturnsGetAssetResponse()
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<SearchAssetRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new SearchAssetResponse());
            var request = new SearchAssetRequest();
            //act
            var response = await _classUnderTest.Get(request);
            //assert
            response.Should().NotBeNull();
        }

        [Test]
        public void GivenInValidRequest_ThenThrowsBadRequestException()
        {
            //arrange
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<SearchAssetRequest>(), It.IsAny<CancellationToken>())).Throws<BadRequestException>();
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.Get(null));
        }
    }
}
