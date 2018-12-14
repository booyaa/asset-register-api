using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Migrations;
using HomesEngland.Gateway.Sql;
using HomesEngland.Gateway.Sql.Postgres;
using HomesEngland.UseCase.CalculateAssetAggregates.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestHelper;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class AssetAggregatorGatewayTests
    {
        private readonly IAssetAggregator _classUnderTest;
        private readonly IGateway<IAsset, int> _gateway;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public AssetAggregatorGatewayTests()
        {
            _databaseConnectionFactory = new PostgresDatabaseConnectionFactory(new PostgresDatabaseConnectionStringFormatter());
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var connection = _databaseConnectionFactory.Create(databaseUrl);
            var gateway = new SqlAssetGateway(connection);
            _gateway = gateway;
            _classUnderTest = gateway;
            var assetRegisterContext = new AssetRegisterContext(databaseUrl);
            assetRegisterContext.Database.Migrate();
        }

        [TestCase(2, 1, 1001, null,null)]
        [TestCase(2, 1, 2002, null,null)]
        [TestCase(2, 1, 3003, null,null)]
        [TestCase(2, 2, null, "test unique", "test")]
        [TestCase(2, 2, null, "Test unique", "test")]
        [TestCase(2, 2, null, "uniiique"   , "unii")]
        [TestCase(2, 2, null, "testing 4"  , "tes")]
        [TestCase(2, 2, null, "Testing 4"  , "tes")]
        [TestCase(2, 2, null, "test uniQue", "que")]
        [TestCase(2, 2, null, "uniiique", null)]
        [TestCase(2, 2, null, " ", null)]
        [TestCase(2, 2, null, "", null)]
        [TestCase(2, 2, null, " ", " ")]
        [TestCase(2, 2, null, "", "")]
        [TestCase(2, 2, null, null, null)]
        [TestCase(2, 0, null, "testing 4", "3")]
        [TestCase(2, 0, null, "testing 4", "1")]
        public async Task GivenMultipleAssetsHaveBeenCreated_WhenWeAggregateViaSearchCritera_ThenWeCanFindHowManyUniqueRecordsThereAre(int count, int expectedCount, int? schemeId, string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await CreateAggregatedAssets(count, schemeId, address, null);
                
                var aggregatedSearch = new AssetSearchQuery
                {
                    SchemeId = schemeId,
                    Address = searchAddress
                };
                //act
                var assets = await _classUnderTest.Aggregate(aggregatedSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.UniqueRecords.Should().Be(expectedCount);
                trans.Dispose();
            }
        }

        [TestCase(2, 2, 1000.01, 1001, null, null)]
        [TestCase(2, 2, 1000.01, 2002, null, null)]
        [TestCase(2, 2, 1000.01, 3003, null, null)]
        [TestCase(2, 2, 1000.01, null, "test unique", "test")]
        [TestCase(2, 2, 1000.01, null, "Test unique", "test")]
        [TestCase(2, 2, 1000.01, null, "uniiique", "unii")]
        [TestCase(2, 2, 1000.01, null, "testing 4", "tes")]
        [TestCase(2, 2, 1000.01, null, "Testing 4", "tes")]
        [TestCase(2, 2, 1000.01, null, "test uniQue", "que")]
        [TestCase(2, 2, 1000.01, null, "uniiique", null)]
        [TestCase(2, 2, 1000.01, null, " ", null)]
        [TestCase(2, 2, 1000.01, null, "", null)]
        [TestCase(2, 2, 1000.01, null, " ", " ")]
        [TestCase(2, 2, 1000.01, null, "", "")]
        [TestCase(2, 2, 1000.01, null, null, null)]
        [TestCase(2, 0, 1000.01, null, "testing 4", "3")]
        [TestCase(2, 0, 1000.01, null, "testing 4", "1")]
        public async Task GivenMultipleAssetsHaveBeenCreated_WhenWeAggregateViaSearchCritera_ThenWeCanGetHowMuchMoneyHasBeenPaidOut(int count, int expectedCount, decimal? agencyFairValue, int? schemeId, string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await CreateAggregatedAssets(count, schemeId, address, agencyFairValue);

                var aggregatedSearch = new AssetSearchQuery
                {
                    SchemeId = schemeId,
                    Address = searchAddress
                };
                //act
                var assets = await _classUnderTest.Aggregate(aggregatedSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.MoneyPaidOut.Should().Be(agencyFairValue*expectedCount);
                trans.Dispose();
            }
        }

        private async Task CreateAggregatedAssets(int count, int? schemeId, string address, decimal? agencyFairValue)
        {
            for (int i = 0; i < count; i++)
            {
                await CreateAsset(schemeId, address, agencyFairValue, _gateway);
            }
        }

        private async Task<IAsset> CreateAsset(int? schemeId, string address, decimal? agencyFairValue, IGateway<IAsset, int> gateway)
        {
            var entity = TestData.Domain.GenerateAsset();
            if (schemeId.HasValue)
                entity.SchemeId = schemeId;
            if (!string.IsNullOrEmpty(address))
                entity.Address = address;
            if (agencyFairValue.HasValue)
                entity.AgencyFairValue = agencyFairValue;
            IAsset createdAsset = await gateway.CreateAsync(entity).ConfigureAwait(false);
            return createdAsset;
        }

    }
}
