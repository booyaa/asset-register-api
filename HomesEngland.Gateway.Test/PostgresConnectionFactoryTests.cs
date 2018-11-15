using NUnit.Framework;
using HomesEngland.Gateway;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class PostgresConnectionFactoryTests
    {
        private IDatabaseConnectionFactory _classUnderTest = null;
        public PostgresConnectionFactoryTests()
        {
            _classUnderTest = new PostgresDatabaseConnectionFactory();
        }

        [Test]
        public void GivenValidConnectionString_ThenDoesntThrowExceptionWhenConnectingToDatabase()
        {
            //arrange 
            var connectionString = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            //act
            var connection =_classUnderTest.Create(connectionString);
            //assert
            Assert.DoesNotThrow(()=>connection.Open());
        }

        [Test]
        public void GivenInValidConnectionString_ThenThrowsException()
        {
            //arrange 
            var connectionString = "postgres://username:password/host/dbName";
            //act
            var connection = _classUnderTest.Create(connectionString);
            //assert
            Assert.Throws<System.Exception>(() => connection.Open());
        }
    }
}