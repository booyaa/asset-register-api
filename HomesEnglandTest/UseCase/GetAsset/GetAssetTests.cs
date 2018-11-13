using HomesEngland.Domain;
using HomesEngland.Gateway;
using HomesEngland.UseCase.GetAsset;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GetAsset
{
    [TestFixture]
    public class GetAssetTests
    {
        public IGetAsset _classUnderTest;
        public Mock<IDatabaseEntityReader<Asset, int>> _mockGateway;
        public GetAssetTests()
        {
            _mockGateway = new Mock<IDatabaseEntityReader<Asset, int>>();
            _classUnderTest = new HomesEngland.UseCase.GetAsset.GetAsset(_mockGateway.Object);
        }
    }
}
