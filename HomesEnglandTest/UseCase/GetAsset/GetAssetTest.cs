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
        protected HomesEngland.UseCase.GetAsset UseCase { get; private set; }
        protected abstract IAssetGateway Gateway { get; }
            
        [SetUp]
        public void SetUp()
        {
            UseCase = new HomesEngland.UseCase.GetAsset(Gateway);
        }
        
        protected Mock<IAssetGateway> CreateMockToReturnAssetWithName(int id, string address, string schemaID, string accountingYear)
        {
            Mock<IAssetGateway>  mock = new Mock<IAssetGateway>();
            mock.Setup(gateway => gateway.GetAsset(id)).ReturnsAsync(() =>
            {
                Asset asset = TestHelper.TestData.Domain.GenerateAsset();
                asset.SchemeID = schemaID;
                asset.Address = address;
                asset.AccountingYear = accountingYear;
                return asset;
            });
            return mock;
        }
    }
}