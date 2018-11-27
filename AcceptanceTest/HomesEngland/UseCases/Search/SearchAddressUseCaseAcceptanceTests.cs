using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Exception;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.SearchAsset;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Exceptions;
using Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestHelper;

namespace AssetRegisterTests.HomesEngland.UseCases.Search
{
    [TestFixture]
    public class SearchAddressUseCaseAcceptanceTests
    {
        private readonly ICreateAssetUseCase _createAssetUseCase;
        private readonly ISearchAssetUseCase _classUnderTest;
        private readonly IGateway<IAsset, int> _gateway;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public SearchAddressUseCaseAcceptanceTests()
        {
            IServiceCollection services = new ServiceCollection();
            var assetRegister = new AssetRegister();
            assetRegister.ExportDependencies((type, provider) => services.AddTransient(type, _ => provider()));

            assetRegister.ExportTypeDependencies((type, provider) => services.AddTransient(type, provider));

            var serviceProvider = services.BuildServiceProvider();

            var assetRegisterContext = serviceProvider.GetService<AssetRegisterContext>();
            assetRegisterContext.Database.Migrate();

            _gateway = serviceProvider.GetService<IGateway<IAsset, int>>();
            _createAssetUseCase = serviceProvider.GetService<ICreateAssetUseCase>();
            _classUnderTest = serviceProvider.GetService<ISearchAssetUseCase>();
        }

        [TestCase("192 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        [TestCase("193 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        [TestCase("194 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaAddressThatHasBeenSet_ThenWeCanFindTheSameAsset(string address)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAssetWithAddress(address);
                //act
                var foundAsset = await SearchForAssetViaSchemeId(address);
                //assert
                ExpectFoundAssetIsEqual(foundAsset, createdAsset);

                trans.Dispose();
            }
        }

        private async Task<SearchAssetResponse> SearchForAssetViaSchemeId(string address)
        {
            var searchForAssetViaSchemeId = new SearchAssetRequest
            {
                Address = address
            };

            var useCaseResponse = await _classUnderTest.ExecuteAsync(searchForAssetViaSchemeId, CancellationToken.None).ConfigureAwait(false);
            return useCaseResponse;
        }

        private void ExpectFoundAssetIsEqual(SearchAssetResponse foundAsset, CreateAssetResponse createdAsset)
        {
            foundAsset.Should().NotBeNull();
            foundAsset.Assets.Should().NotBeNullOrEmpty();
            foundAsset.Assets.ElementAt(0).AssetOutputModelIsEqual(createdAsset.Asset);
        }

        [TestCase("195 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY", "201 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        [TestCase("196 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY", "202 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        [TestCase("197 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY", "203 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasBeenSet_ThenWeCanFindTheSameAssetAnd(string address, string address2)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAssetWithAddress(address);
                var createdAsset2 = await CreateAssetWithAddress(address2);

                var assetSearch = new SearchAssetRequest
                {
                    Address = address2
                };
                //act
                var useCaseResponse = await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                useCaseResponse.Assets.Count.Should().Be(1);
                useCaseResponse.Assets.ElementAtOrDefault(0).AssetOutputModelIsEqual(createdAsset2.Asset);
                trans.Dispose();
            }
        }

        [TestCase("192 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        [TestCase("193 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        [TestCase("194 Evergreen Terrace, Sunny Place, Egham, Surrey, TW20 8TY")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasntBeenSet_ThenWeThrowAnException(string address)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = TestData.Domain.GenerateAsset();

                var createdAsset = await _gateway.CreateAsync(entity).ConfigureAwait(false);
                var assetSearch = new SearchAssetRequest
                {
                    Address = address
                };
                //act 
                //assert
                Assert.ThrowsAsync<AssetNotFoundException>(async () => await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false));
                trans.Dispose();
            }
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void GivenAnInvalidRequest_ThenWeThrowBadRequestException(string address)
        {
            //arrange 
            SearchAssetRequest assetSearch = new SearchAssetRequest
            {
                Address = address
            };
            //act 
            //assert
            Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false));
        }

        private async Task<CreateAssetResponse> CreateAssetWithAddress(string address)
        {
            var createAssetRequest = TestData.UseCase.GenerateCreateAssetRequest();
            createAssetRequest.Address = address;
            var response = await _createAssetUseCase.ExecuteAsync(createAssetRequest, CancellationToken.None);
            return response;
        }
    }
}