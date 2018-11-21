using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.SearchAsset.Impl;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Exceptions;
using NSubstitute;
using NUnit.Framework;
using TestHelper;

namespace HomesEnglandTest.UseCase.SearchAsset
{
    [TestFixture]
    public class SearchAssetTests
    {
        private readonly ISearchAssetUseCase _classUnderTest;
        private readonly IAssetSearcher _mockGateway;

        public SearchAssetTests()
        {
            _mockGateway = Substitute.For<IAssetSearcher>();
            _classUnderTest = new SearchAssetUseCase(_mockGateway);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenValidSchemeId_UseCaseCallsGatewayWithCorrectId(int id)
        {
            await _classUnderTest.ExecuteAsync(new SearchAssetRequest
            {
                SchemeId = id
            }, CancellationToken.None);

            await _mockGateway.Received()
                .Search(Arg.Is<AssetSearchQuery>(req => req.SchemeId == id), Arg.Any<CancellationToken>());
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GivenValidRequestId_UseCaseReturnsCorrectlyMappedAsset(int id)
        {
            //arrange
            var asset = TestData.Domain.GenerateAsset();
            asset.SchemeId = id;
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns(new List<IAsset> {asset});
            //act
            var response = await _classUnderTest.ExecuteAsync(new SearchAssetRequest
            {
                SchemeId = id
            }, CancellationToken.None);
            //assert
            response.Should().NotBeNull();
            response.Assets.Should().NotBeNullOrEmpty();
            response.Assets[0].Should().BeEquivalentTo(asset);
        }

        [TestCase(1, 2)]
        [TestCase(3, 4)]
        [TestCase(5, 6)]
        public async Task GivenValidRequestIdAndMultipleAssetsReturned_UseCaseReturnsCorrectlyMappedAssets(int idOne,
            int idTwo)
        {
            var assetOne = TestData.Domain.GenerateAsset();
            assetOne.SchemeId = idOne;

            var assetTwo = TestData.Domain.GenerateAsset();
            assetOne.SchemeId = idTwo;

            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None)
                .Returns(new List<IAsset> {assetOne, assetTwo});
            //act
            var response = await _classUnderTest.ExecuteAsync(new SearchAssetRequest
            {
                SchemeId = idOne
            }, CancellationToken.None);
            //assert
            response.Should().NotBeNull();
            response.Assets.Should().NotBeNullOrEmpty();
            response.Assets[0].Should().BeEquivalentTo(assetOne);
            response.Assets[1].Should().BeEquivalentTo(assetTwo);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GivenNoAssetsFoundForSchemeId_UseCaseThrowsAssetNotFoundException(int id)
        {
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns(new List<IAsset>());

            Assert.ThrowsAsync<AssetNotFoundException>(async () => await
                _classUnderTest.ExecuteAsync(new SearchAssetRequest {SchemeId = id}, CancellationToken.None));
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void GivenValidRequest_WhenSearchResultsAreNull_ThenUseCaseThrowsAssetNotFoundException(int id)
        {
            //arrange
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns((IList<IAsset>) null);
            var searchAssetRequest = new SearchAssetRequest
            {
                SchemeId = id
            };
            //act
            //assert
            Assert.ThrowsAsync<AssetNotFoundException>(async () =>
                await _classUnderTest.ExecuteAsync(searchAssetRequest, CancellationToken.None));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void GivenInValidRequest_ThenUseCaseThrowsBadRequestException(int? id)
        {
            //arrange
            IAssetSearchQuery searchQueryAssetRequest = new AssetSearchQuery
            {
                SchemeId = id
            };
            var assetRequest = new SearchAssetRequest {SchemeId = id};
            _mockGateway.Search(searchQueryAssetRequest, CancellationToken.None).Returns((IList<IAsset>) null);
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () =>
                await _classUnderTest.ExecuteAsync(assetRequest, CancellationToken.None));
        }

        [Test]
        public void GivenNullRequest_UseCaseReturnsCorrectlyMappedAsset()
        {
            //arrange
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () =>
                await _classUnderTest.ExecuteAsync(null, CancellationToken.None));
        }
    }
}
