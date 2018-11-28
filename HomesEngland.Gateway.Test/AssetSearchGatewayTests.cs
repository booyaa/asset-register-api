using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Migrations;
using HomesEngland.Gateway.Sql;
using HomesEngland.Gateway.Sql.Postgres;
using HomesEngland.UseCase.SearchAsset.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestHelper;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class AssetSearchGatewayTests
    {
        private readonly IAssetSearcher _classUnderTest;
        private readonly IGateway<IAsset, int> _gateway;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public AssetSearchGatewayTests()
        {
            _databaseConnectionFactory = new PostgresDatabaseConnectionFactory(new PostgresDatabaseConnectionStringFormatter());
            var databaseUrl = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            var connection = _databaseConnectionFactory.Create(databaseUrl);
            var gateway = new SqlAssetGateway(connection);
            _gateway = gateway;
            _classUnderTest = gateway;
            var assetRegisterContext = new AssetRegisterContext(databaseUrl);
            assetRegisterContext.Database.Migrate();
        }

        [TestCase(1001)]
        [TestCase(2002)]
        [TestCase(3003)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasBeenSet_ThenWeCanFindTheSameAsset(int schemeId)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAsset(schemeId, null, _gateway);
                var assetSearch = new AssetSearchQuery
                {
                    SchemeId = schemeId
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.ElementAtOrDefault(0).AssetIsEqual(createdAsset.Id, createdAsset);
                trans.Dispose();
            }
        }


        [TestCase(7007, 7008, 7009)]
        [TestCase(2002, 2004, 2005)]
        [TestCase(3003,3004,3005)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasBeenSet_ThenWeCanFindTheSameAssetAnd(int schemeId, int schemeId2, int schemeId3)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAsset(schemeId, null, _gateway);
                var createdAsset2 = await CreateAsset(schemeId2, null, _gateway);
                var createdAsset3 = await CreateAsset(schemeId3, null, _gateway);

                var assetSearch = new AssetSearchQuery
                {
                    SchemeId = schemeId2
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.Count.Should().Be(1);
                assets.ElementAtOrDefault(0).AssetIsEqual(createdAsset2.Id, createdAsset2);
                trans.Dispose();
            }
        }

        [TestCase(4004)]
        [TestCase(5005)]
        [TestCase(6006)]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaSchemeIdThatHasntBeenSet_ThenWeCantFindTheSameAsset(int schemeId)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = TestData.Domain.GenerateAsset();
                
                await _gateway.CreateAsync(entity).ConfigureAwait(false);
                var assetSearch = new AssetSearchQuery
                {
                    SchemeId = schemeId
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.Should().BeNullOrEmpty();
                trans.Dispose();
            }
        }

        private async Task<IAsset> CreateAsset(int? schemeId, string address, IGateway<IAsset,int> gateway)
        {
            var entity = TestData.Domain.GenerateAsset();
            if(schemeId.HasValue)
                entity.SchemeId = schemeId;
            if (string.IsNullOrEmpty(address))
                entity.Address = address;
            IAsset createdAsset = await gateway.CreateAsync(entity).ConfigureAwait(false);
            return createdAsset;
        }

        [TestCase("Address 1")]
        [TestCase("Address 2")]
        [TestCase("Address 3")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaExactAddress_ThenWeCanFindTheSameAsset(string address)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAsset(null, address, _gateway);
                var assetSearch = new AssetSearchQuery
                {
                    Address = address
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.ElementAtOrDefault(0).AssetIsEqual(createdAsset.Id, createdAsset);
                trans.Dispose();
            }
        }

        [TestCase("Address 1", "Addr")]
        [TestCase("Address 2", "Addr")]
        [TestCase("Address 3", "Addr")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaStartsWith_ThenWeCanFindTheSameAsset(string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAsset(null, address, _gateway);
                var assetSearch = new AssetSearchQuery
                {
                    Address = searchAddress
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.ElementAtOrDefault(0).AssetIsEqual(createdAsset.Id, createdAsset);
                trans.Dispose();
            }
        }

        [TestCase("Address 1", "ss 1")]
        [TestCase("Address 2", "ress 2")]
        [TestCase("Address 3", "3")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaEndWith_ThenWeCanFindTheSameAsset(string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAsset(null, address, _gateway);
                var assetSearch = new AssetSearchQuery
                {
                    Address = searchAddress
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.ElementAtOrDefault(0).AssetIsEqual(createdAsset.Id, createdAsset);
                trans.Dispose();
            }
        }

        [TestCase("Address 1", "address 1")]
        [TestCase("Address 2", "addres")]
        [TestCase("Address 3", "Add")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaLowerCase_ThenWeCanFindTheSameAsset(string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdAsset = await CreateAsset(null, address, _gateway);
                var assetSearch = new AssetSearchQuery
                {
                    Address = searchAddress
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.ElementAtOrDefault(0).AssetIsEqual(createdAsset.Id, createdAsset);
                trans.Dispose();
            }
        }


        [TestCase(null, "address 1")]
        [TestCase(null, "addres")]
        [TestCase(null, "Add")]
        public async Task GivenAnAssetHasBeenCreated_WhenWeSearchViaForAnAddressThatDoesntExist_ThenWeReturnNullOrEmptyList(string address, string searchAddress)
        {
            //arrange 
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await CreateAsset(null, address, _gateway);
                var assetSearch = new AssetSearchQuery
                {
                    Address = searchAddress
                };
                //act
                var assets = await _classUnderTest.Search(assetSearch, CancellationToken.None).ConfigureAwait(false);
                //assert
                assets.Should().BeNullOrEmpty();
                trans.Dispose();
            }
        }
    }
}
