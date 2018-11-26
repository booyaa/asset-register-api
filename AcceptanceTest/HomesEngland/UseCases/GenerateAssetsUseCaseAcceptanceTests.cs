using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GenerateAssets.Models;
using HomesEngland.UseCase.GetAsset;
using Infrastructure.Api.Exceptions;
using Main;
using NUnit.Framework;

namespace AssetRegisterTests.HomesEngland.UseCases
{
    [TestFixture]
    public class GenerateAssetsUseCaseTest
    {
        private IGenerateAssetsUseCase _classUnderTest;
        private ISearchAssetUseCase _searchAssetUseCase;
        public GenerateAssetsUseCaseTest()
        {
            var assetRegister = new AssetRegister();
            _classUnderTest = assetRegister.Get<IGenerateAssetsUseCase>();
            _searchAssetUseCase = assetRegister.Get<ISearchAssetUseCase>();
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GivenWeGenerateSomeAssets_ThenWeKnowHowManyAssetsWereCreated(int recordCount)
        {
            //arrange 
            var request = new GenerateAssetsRequest
            {
                Records = recordCount
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            response.RecordsGenerated.Count.Should().Be(recordCount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GivenWeGenerateSomeAssets_WhenWeSearchForAssets_ThenWeCanFindThoseRecords(int recordCount)
        {
            //arrange 
            var request = new GenerateAssetsRequest
            {
                Records = recordCount
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            response.RecordsGenerated.Count.Should().Be(recordCount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public async Task GivenInValidRequest_ThenUseCaseThrowsBadRequestException(int? recordCount)
        {
            //arrange 
            var request = new GenerateAssetsRequest
            {
                Records = recordCount
            };
            //act
            //assert
            Assert.ThrowsAsync<BadRequestException>(async ()=> await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false));
        }
    }
}
