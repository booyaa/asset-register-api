using System;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Sql.Postgres;
using NUnit.Framework;
using TestHelper;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class SqlGatewayTests
    {
        private readonly IGateway<IAsset,int> _classUnderTest;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public SqlGatewayTests()
        {
            _databaseConnectionFactory = new PostgresDatabaseConnectionFactory(new PostgresDatabaseConnectionStringFormatter());
            var databaseUrl = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            var connection = _databaseConnectionFactory.Create(databaseUrl);
            _classUnderTest = new SqlAssetGateway(connection);
        }

        [Test]
        public async Task GivenAnAssetHasBeenCreated_WhenTheAssetIsReadFromTheGateway_ThenItIsTheSame()
        {
            //arrange 
            var entity = TestData.Domain.GenerateAsset();
            var createdAsset = await _classUnderTest.CreateAsync(entity).ConfigureAwait(false);
            //act
            var readAsset = await _classUnderTest.ReadAsync(createdAsset.Id).ConfigureAwait(false);
            
            //assert
            readAsset.Id.Should().Be(createdAsset.Id);
            readAsset.AccountingYear.Should().BeEquivalentTo(entity.AccountingYear);
            readAsset.Address.Should().BeEquivalentTo(entity.Address);
            readAsset.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            readAsset.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.Deposit.Should().Be(entity.Deposit);
            readAsset.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            readAsset.DevelopingRslName.Should().Be(entity.DevelopingRslName);
            readAsset.DifferenceFromImsExpectedCompletionToHopCompletionDate.Should().Be(entity.DifferenceFromImsExpectedCompletionToHopCompletionDate);
            readAsset.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            readAsset.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            readAsset.MonthPaid.Should().BeEquivalentTo(entity.MonthPaid);
            readAsset.NoOfBeds.Should().BeEquivalentTo(entity.NoOfBeds);
            readAsset.SchemeId.Should().BeEquivalentTo(entity.SchemeId);
            readAsset.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
        }
    }
}
