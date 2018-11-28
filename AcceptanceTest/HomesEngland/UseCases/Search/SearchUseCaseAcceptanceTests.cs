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
    public class SearchUseCaseAcceptanceTests
    {
        private readonly ICreateAssetUseCase _createAssetUseCase;
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
            _createAssetUseCase = serviceProvider.GetService<ICreateAssetUseCase>();
            _classUnderTest = serviceProvider.GetService<ISearchAssetUseCase>();
        }

        [TestCase(1111, null)]
        [TestCase(2222, null)]
        [TestCase(3333, null)]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "add")]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "Address 1")]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "somewh")]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "where")]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "PO")]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "Tow")]
        [TestCase(null, "Address 1, Somewhere road, Town, Region, PO57 C03", "C03")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearch_ThenWeCanFindTheSameAsset(int? schemeId, string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAssetWithSchemeId(schemeId, address);
                //act
                var foundAsset = await SearchForAsset(schemeId, searchAddress);
                //assert
                ExpectFoundAssetIsEqual(foundAsset, createdAsset);

                trans.Dispose();
            }
        }

        private async Task<SearchAssetResponse> SearchForAsset(int? schemeId, string address)
        {
            var searchForAssetViaSchemeId = new SearchAssetRequest
            {
                SchemeId = schemeId,
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

        [TestCase(7777, 7778, 7779,"address")]
        [TestCase(2222, 2224, 2225,"address")]
        [TestCase(3333, 3334, 3335,"address")]
        public async Task GivenThatMultipleAssetsHaveBeenCreated_WhenWeSearchViaSchemeIdThatHasBeenSet_ThenWeCanFindTheSameAssetAnd(int schemeId, int schemeId2, int schemeId3, string address)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAssetWithSchemeId(schemeId, address);
                var createdAsset2 = await CreateAssetWithSchemeId(schemeId2, address);
                var createdAsset3 = await CreateAssetWithSchemeId(schemeId3, address);

                var assetSearch = new SearchAssetRequest
                {
                    SchemeId = schemeId2
                };
                //act
                var useCaseResponse = await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None)
                    .ConfigureAwait(false);
                //assert
                useCaseResponse.Assets.Count.Should().Be(1);
                useCaseResponse.Assets.ElementAtOrDefault(0).AssetOutputModelIsEqual(createdAsset2.Asset);
                trans.Dispose();
            }
        }

        [TestCase(4444)]
        [TestCase(5555)]
        [TestCase(6666)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasntBeenSet_ThenWeReturnNullOrEmptyList(int schemeId)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = TestData.Domain.GenerateAsset();

                await _gateway.CreateAsync(entity).ConfigureAwait(false);
                var assetSearch = new SearchAssetRequest
                {
                    SchemeId = schemeId
                };
                //act 
                //assert
                var response = await _classUnderTest.ExecuteAsync(assetSearch, CancellationToken.None).ConfigureAwait(false);
                response.Should().NotBeNull();
                response.Assets.Should().BeNullOrEmpty();
                trans.Dispose();
            }
        }



        private async Task<CreateAssetResponse> CreateAssetWithSchemeId(int? schemeId, string address)
        {
            var createAssetRequest = TestData.UseCase.GenerateCreateAssetRequest();
            if(schemeId.HasValue)
                createAssetRequest.SchemeId = schemeId;
            if (string.IsNullOrEmpty(address))
                createAssetRequest.Address = address;
            var response = await _createAssetUseCase.ExecuteAsync(createAssetRequest, CancellationToken.None);
            return response;
        }
    }
}
