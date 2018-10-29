using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Gateway.AssetGateway;
using NUnit.Framework;

namespace HomesEnglandTest.Gateway.AssetGateway.InMemoryGateway
{
    [TestFixture]
    public abstract class InMemoryAssetGatewaySearchTest:AssetGatewaySearchTest
    {
        protected override IAssetGateway AssetGateway { get; set; }
        [SetUp]
        public override async Task SetUp()
        {
            AssetGateway = new InMemoryAssetGateway();
            await base.SetUp();
        }
    }
}