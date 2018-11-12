using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public Mock<IEntityReader<Asset, int>> _mockGateway;
        public GetAssetTests()
        {
            _mockGateway = new Mock<IEntityReader<Asset, int>>();
            _classUnderTest = new HomesEngland.UseCase.GetAsset.GetAsset(_mockGateway.Object);
        }

    }
}
