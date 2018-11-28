using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.SearchAsset;
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
            //arrange
            var asset = TestData.Domain.GenerateAsset();
            asset.SchemeId = id;
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns(new List<IAsset> { asset });
            //act
            await _classUnderTest.ExecuteAsync(new SearchAssetRequest
            {
                SchemeId = id
            }, CancellationToken.None);
            //assert
            await _mockGateway.Received()
                .Search(Arg.Is<AssetSearchQuery>(req => req.SchemeId == id), Arg.Any<CancellationToken>());
        }

        [TestCase(1, null)]
        [TestCase(2, null)]
        [TestCase(3, null)]
        [TestCase(null, "d")]
        [TestCase(null, "e")]
        [TestCase(null, "t")]
        public async Task GivenValidRequestId_UseCaseReturnsCorrectlyMappedAsset(int? id, string address)
        {
            //arrange
            var asset = TestData.Domain.GenerateAsset();
            if(id.HasValue)
                asset.SchemeId = id;
            if (!string.IsNullOrEmpty(address))
                asset.Address = address;
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns(new List<IAsset> {asset});
            //act
            var response = await _classUnderTest.ExecuteAsync(new SearchAssetRequest
            {
                SchemeId = id,
                Address = address
            }, CancellationToken.None);
            //assert
            response.Should().NotBeNull();
            response.Assets.Should().NotBeNullOrEmpty();
            response.Assets[0].Should().BeEquivalentTo(asset);
        }

        [TestCase(1, 2)]
        [TestCase(3, 4)]
        [TestCase(5, 6)]
        public async Task GivenValidRequestIdAndMultipleAssetsReturned_UseCaseReturnsCorrectlyMappedAssets(int idOne, int idTwo)
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

        [TestCase(1, null)]
        [TestCase(2, "")]
        [TestCase(3, " ")]
        [TestCase(null, "a")]
        [TestCase(null, "b")]
        [TestCase(null, "c")]
        public async Task GivenValidInput_WhenNoAssetsFoundForSchemeId_ThenUseCaseThrowsAssetReturnsNull(int? id, string address)
        {
            //arrange
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns(new List<IAsset>());
            //act
            var response = await _classUnderTest.ExecuteAsync(new SearchAssetRequest {SchemeId = id, Address = address}, CancellationToken.None);
            //assert
            response.Should().NotBeNull();
            response.Assets.Should().BeNullOrEmpty();
        }

        [TestCase(1, null)]
        [TestCase(2, null)]
        [TestCase(3, null)]
        [TestCase(null, "d")]
        [TestCase(null, "e")]
        [TestCase(null, "t")]
        public async Task GivenValidRequest_WhenSearchResultsAreNull_ThenUseCaseThrowsAssetNotFoundException(int id, string address)
        {
            //arrange
            _mockGateway.Search(Arg.Any<IAssetSearchQuery>(), CancellationToken.None).Returns((IList<IAsset>) null);
            var searchAssetRequest = new SearchAssetRequest
            {
                SchemeId = id,
                Address = address
            };
            //act
            //act
            var response = await _classUnderTest.ExecuteAsync(searchAssetRequest, CancellationToken.None);
            //assert
            response.Should().NotBeNull();
            response.Assets.Should().BeNullOrEmpty();
        }

        [TestCase(null, null)]
        [TestCase(0, null)]
        [TestCase(-1, null)]
        [TestCase(null, "")]
        [TestCase(null, " ")]
        public void GivenInValidRequest_ThenUseCaseThrowsBadRequestException(int? id, string address)
        {
            //arrange
            IAssetSearchQuery searchQueryAssetRequest = new AssetSearchQuery
            {
                SchemeId = id,
                Address = address
            };
            var assetRequest = new SearchAssetRequest {SchemeId = id};
            _mockGateway.Search(searchQueryAssetRequest, CancellationToken.None).Returns((IList<IAsset>) null);
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(assetRequest, CancellationToken.None));
        }

        [Test]
        public void GivenAnInvalidRequest_ThenWeThrowBadRequestException()
        {
            //arrange 
            SearchAssetRequest assetSearch = null;
            //act 
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () =>
                await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false));
        }
    }
}
