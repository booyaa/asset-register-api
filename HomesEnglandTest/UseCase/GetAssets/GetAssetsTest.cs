using HomesEngland.Boundary;
using HomesEngland.Boundary.Port;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GetAssets
{
    [TestFixture]
    public abstract class GetAssetsTest
    {
        protected HomesEngland.UseCase.Assets.GetAssets UseCase { get; set; }
        protected abstract IAssetGateway Gateway { get; }
            
        [SetUp]
        public void SetUp()
        {
            UseCase = new HomesEngland.UseCase.Assets.GetAssets(Gateway);
        }
    }
}