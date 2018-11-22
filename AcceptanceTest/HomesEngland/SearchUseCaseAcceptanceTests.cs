using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Models;
using Infrastructure.Api.Exceptions;
using Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestHelper;

namespace AssetRegisterTests.HomesEngland
{
    [TestFixture]
    public class SearchUseCaseAcceptanceTests
    {
        private readonly ISearchAssetUseCase _classUnderTest;
        private readonly IGateway<IAsset, int> _gateway;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public SearchUseCaseAcceptanceTests()
        {
            IServiceCollection services = new ServiceCollection();
            var assetRegister = new AssetRegister();
            assetRegister.ExportDependencies((type, provider) => services.AddTransient(type, _ => provider()));

            assetRegister.ExportTypeDependencies((type, provider) => services.AddTransient(type, provider));

            var serviceProvider = services.BuildServiceProvider();

            var assetRegisterContext = serviceProvider.GetService<AssetRegisterContext>();
            assetRegisterContext.Database.Migrate();

            _gateway = serviceProvider.GetService<IGateway<IAsset, int>>();
            _classUnderTest = serviceProvider.GetService<ISearchAssetUseCase>();
        }

        [TestCase(1111)]
        [TestCase(2222)]
        [TestCase(3333)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasBeenSet_ThenWeCanFindTheSameAsset(int schemeId)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAssetWithSchemeId(schemeId);
                //act
                var foundAsset = await SearchForAssetViaSchemeId(schemeId);
                //assert
                ExpectFoundAssetIsEqual(foundAsset, createdAsset);

                trans.Dispose();
            }
        }

        private async Task<SearchAssetResponse> SearchForAssetViaSchemeId(int schemeId)
        {
            var searchForAssetViaSchemeId = new SearchAssetRequest
            {
                SchemeId = schemeId
            };

            var useCaseResponse = await _classUnderTest.ExecuteAsync(searchForAssetViaSchemeId, CancellationToken.None)
                .ConfigureAwait(false);
            return useCaseResponse;
        }

        private void ExpectFoundAssetIsEqual(SearchAssetResponse foundAsset, IAsset createdAsset)
        {
            foundAsset.Should().NotBeNull();
            foundAsset.Assets.Should().NotBeNullOrEmpty();
            foundAsset.Assets.ElementAtOrDefault(0).AssetOutputModelIsEqual(createdAsset);
        }

        [TestCase(7777, 7778, 7779)]
        [TestCase(2222, 2224, 2225)]
        [TestCase(3333, 3334, 3335)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasBeenSet_ThenWeCanFindTheSameAssetAnd(int schemeId, int schemeId2, int schemeId3)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAssetWithSchemeId(schemeId);
                var createdAsset2 = await CreateAssetWithSchemeId(schemeId2);
                var createdAsset3 = await CreateAssetWithSchemeId(schemeId3);

                var assetSearch = new SearchAssetRequest
                {
                    SchemeId = schemeId2
                };
                //act
                var useCaseResponse = await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                useCaseResponse.Assets.Count.Should().Be(1);
                useCaseResponse.Assets.ElementAtOrDefault(0).AssetOutputModelIsEqual(createdAsset2);
                trans.Dispose();
            }
        }

        [TestCase(4444)]
        [TestCase(5555)]
        [TestCase(6666)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasntBeenSet_ThenWeThrowAnException(
            int schemeId)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = TestData.Domain.GenerateAsset();

                var createdAsset = await _gateway.CreateAsync(entity).ConfigureAwait(false);
                var assetSearch = new SearchAssetRequest
                {
                    SchemeId = schemeId
                };
                //act 
                //assert
                Assert.ThrowsAsync<AssetNotFoundException>(async () =>await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false));
                trans.Dispose();
            }
        }

        [Test]
        public void GivenAnInvalidRequest_ThenWeThrowBadRequestException()
        {
            //arrange 
            SearchAssetRequest assetSearch = null;
            //act 
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void GivenAnInvalidRequest_ThenWeThrowBadRequestException(int schemeId)
        {
            //arrange 
            SearchAssetRequest assetSearch = new SearchAssetRequest
            {
                SchemeId = schemeId
            };
            //act 
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false));
        }

        private async Task<IAsset> CreateAssetWithSchemeId(int schemeId)
        {
            var entity = TestData.Domain.GenerateAsset();
            entity.SchemeId = schemeId;
            IAsset createdAsset = await _gateway.CreateAsync(entity).ConfigureAwait(false);
            return createdAsset;
        }
    }
}
