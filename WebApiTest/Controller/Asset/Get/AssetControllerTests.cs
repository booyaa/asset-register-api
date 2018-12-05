using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Models;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;
using FluentAssertions;
using Infrastructure.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TestHelper;

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
        public async Task GivenValidRequestWithAcceptTextCsvHeader_ThenReturnsListOfAssetOutputModel()
        {
            //arrange
            var assetOutputModel = new AssetOutputModel(TestData.Domain.GenerateAsset());
            assetOutputModel.Id = Faker.GlobalUniqueIndex;
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetAssetRequest>())).ReturnsAsync(new GetAssetResponse
            {
                Asset = assetOutputModel
            });
            _classUnderTest.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            _classUnderTest.ControllerContext.HttpContext.Request.Headers.Add(new KeyValuePair<string, StringValues>("accept", "text/csv"));
            var request = new GetAssetRequest
            {
                Id = assetOutputModel.Id
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
            _mockUseCase.Setup(s => s.ExecuteAsync(It.IsAny<GetAssetRequest>())).Throws<BadRequestException>();
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async ()=> await _classUnderTest.Get(null));
        }
    }
}
