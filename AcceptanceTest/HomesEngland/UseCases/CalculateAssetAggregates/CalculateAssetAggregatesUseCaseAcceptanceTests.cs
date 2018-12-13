using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.CalculateAssetAggregates;
using HomesEngland.UseCase.CalculateAssetAggregates.Models;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using Main;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestHelper;

namespace AssetRegisterTests.HomesEngland.UseCases.CalculateAssetAggregates
{
    [TestFixture]
    public class CalculateAssetAggregatesUseCaseAcceptanceTests
    {
        private readonly ICreateAssetUseCase _createAssetUseCase;
        private readonly ICalculateAssetAggregatesUseCase _classUnderTest;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public CalculateAssetAggregatesUseCaseAcceptanceTests()
        {
            var assetRegister = new AssetRegister();
            var assetRegisterContext = assetRegister.Get<AssetRegisterContext>();
            assetRegisterContext.Database.Migrate();
            _createAssetUseCase = assetRegister.Get<ICreateAssetUseCase>();
            _classUnderTest = assetRegister.Get<ICalculateAssetAggregatesUseCase>();
        }

        [TestCase(3, 1, 1111, null, null)]
        [TestCase(3, 1, 2222, null, null)]
        [TestCase(3, 1, 3333, null, null)]
        [TestCase(3, 3, null, "Address 10, Somewhere road, City, Region, PO57 C03", "Address 10")]
        [TestCase(2, 2, null, "Address 10, Somewhere road, City, Region, PO57 C03", "somewh")]
        [TestCase(1, 1, null, "Address 10, Somewhere road, City, Region, PO57 C03", "where")]
        [TestCase(3, 3, null, "Address 10, Somewhere road, City, Region, PO57 C03", "PO57")]
        [TestCase(3, 3, null, "Address 10, Somewhere road, City, Region, PO57 C03", "City")]
        [TestCase(3, 3, null, "Address 10, Somewhere road, City, Region, PO57 C03", "C03")]
        public async Task GivenMultipleAssetsHaveBeenCreated_WhenWeSearch_ThenWeCanGetTheTotalUniqueRecordsCount(int createdCount, int expectedCount, int? schemeId, string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await GenerateAssetsForAggregation(createdCount, schemeId, address);
                //act
                var searchAggregate = await CalculateAggregatesForSearchCriteria(schemeId, searchAddress);
                //assert
                searchAggregate.AssetAggregates.UniqueRecords.Should().Be(expectedCount);
                trans.Dispose();
            }
        }

        private async Task GenerateAssetsForAggregation(int createdCount, int? schemeId, string address)
        {
            for (int i = 0; i < createdCount; i++)
            {
                await CreateAsset(schemeId, address);
            }
        }

        private async Task<CalculateAssetAggregateResponse> CalculateAggregatesForSearchCriteria(int? schemeId, string address)
        {
            var searchForAsset = new CalculateAssetAggregateRequest
            {
                SchemeId = schemeId,
                Address = address
            };

            var useCaseResponse = await _classUnderTest.ExecuteAsync(searchForAsset, CancellationToken.None).ConfigureAwait(false);
            return useCaseResponse;
        }

        private async Task<CreateAssetResponse> CreateAsset(int? schemeId, string address)
        {
            var createAssetRequest = TestData.UseCase.GenerateCreateAssetRequest();
            if (schemeId.HasValue)
                createAssetRequest.SchemeId = schemeId;
            if (!string.IsNullOrEmpty(address))
                createAssetRequest.Address = address;
            var response = await _createAssetUseCase.ExecuteAsync(createAssetRequest, CancellationToken.None);
            return response;
        }
    }
}
