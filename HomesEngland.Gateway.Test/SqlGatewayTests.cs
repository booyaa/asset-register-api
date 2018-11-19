using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using NUnit.Framework;
using TestHelper;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class SqlGatewayTests
    {
        private readonly IGateway<IAsset, int> _classUnderTest;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public SqlGatewayTests()
        {
            _databaseConnectionFactory = new PostgresDatabaseConnectionFactory(new PostgresDatabaseConnectionStringFormatter());
            var databaseUrl = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            var connection = _databaseConnectionFactory.Create(databaseUrl);
            _classUnderTest = new SqlGateway<IAsset, int>(connection);
        }

        [Test]
        public async Task GivenCreate()
        {
            //arrange 
            var entity = TestData.Domain.GenerateAsset();
            try
            {
                var createdAsset = await _classUnderTest.CreateAsync(entity).ConfigureAwait(false);
                //act
                var readAsset = await _classUnderTest.ReadAsync(createdAsset.Id).ConfigureAwait(false);
                //assert
                readAsset.Should().BeEquivalentTo(entity);
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
