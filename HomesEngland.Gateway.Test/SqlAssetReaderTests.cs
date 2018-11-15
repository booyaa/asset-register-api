using HomesEngland;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Assets;
using NUnit.Framework;

namespace HomesEngland.Gateway.Test
{
    [TestFixture]
    public class SqlAssetReaderTests
    {
        private IAssetReader _classUnderTest = null;
        public SqlAssetReaderTests()
        {
            var connectionFactory = new PostgresConnectionFactory();
            _classUnderTest = new SqlAssetReader(null);
        }

        [Test]
        public void GivenValid()
        {
            //arrange 

            //act

            //assert
        }
    }
}
