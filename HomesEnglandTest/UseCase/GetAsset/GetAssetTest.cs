using HomesEngland.Boundary;
using HomesEngland.Boundary.Port;
using HomesEngland.Domain;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GetAsset
{
    [TestFixture]
    public abstract class GetAssetTest
    {
        protected HomesEngland.UseCase.Assets.GetAsset UseCase { get; private set; }
        protected abstract IAssetGateway Gateway { get; }
            
        [SetUp]
        public void SetUp()
        {
            UseCase = new HomesEngland.UseCase.Assets.GetAsset(Gateway);
        }
        
        protected Mock<IAssetGateway> CreateMockToReturnAssetWithName(int id, string address, string schemaID, string accountingYear)
        {
            Mock<IAssetGateway>  mock = new Mock<IAssetGateway>();
            mock.Setup(gateway => gateway.GetAsset(id)).ReturnsAsync(() => new Asset()
            {
                Address = address,
                SchemeId =  schemaID,
                AccountingYear = accountingYear
            });
            return mock;
        }
    }
}