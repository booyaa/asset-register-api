using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.SearchAsset;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using TestHelper;
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
        public async Task GivenValidRequestWithAcceptTextCsvHeader_ThenReturnsListOfAssetOutputModel()
        {
            //arrange
            var assetOutputModel = new AssetOutputModel(TestData.Domain.GenerateAsset());
            assetOutputModel.Id = Faker.GlobalUniqueIndex;
            assetOutputModel.SchemeId = Faker.GlobalUniqueIndex;
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<SearchAssetRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new SearchAssetResponse
            {
                Assets = new List<AssetOutputModel>{ assetOutputModel}
            });
            _classUnderTest.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            _classUnderTest.ControllerContext.HttpContext.Request.Headers.Add(new KeyValuePair<string, StringValues>("accept", "text/csv"));
            var request = new SearchAssetRequest
            {
                SchemeId = assetOutputModel.SchemeId
            };
            //act
            var response = await _classUnderTest.Get(request).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            var result = response as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().BeOfType<List<AssetOutputModel>>();
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
