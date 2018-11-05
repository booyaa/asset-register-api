using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.Port;
using HomesEngland.Exception;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GetAsset.WithNoAsset
{
    [TestFixture]
    public class GivenNoAssets : GetAssetTest
    {
        private readonly Mock<IAssetGateway> _mock;
        protected override IAssetGateway Gateway => _mock.Object;
        private int id => 42;
        public GivenNoAssets()
        {
            _mock = new Mock<IAssetGateway>();
            _mock.Setup(gateway => gateway.GetAsset(id)).ReturnsAsync(() => null);
        }

        [Test]
        public async Task ItThrowsNoAssetException()
        {
            Assert.ThrowsAsync<NoAssetException>(async () => await UseCase.Execute(id));
        }
    }
}