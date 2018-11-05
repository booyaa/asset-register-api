using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Domain;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.SearchAssets
{
    [TestFixture]
    public abstract class SearchAssetsTest
    {
        Mock<IAssetGateway> _mock;
        private ISearchAssets UseCase { get; set; }
        protected Dictionary<string, string>[] SearchResults { get; set; }
        
        protected abstract string SearchQuery { get; }
        protected abstract Asset[] GatewaySearchResults { get;}

        [SetUp]
        public async Task SetUp()
        {
            _mock = new Mock<IAssetGateway>();
            _mock.Setup(gateway => gateway.SearchAssets(SearchQuery)).ReturnsAsync(() => GatewaySearchResults);
            UseCase = new HomesEngland.UseCase.SearchAssets(_mock.Object);
            SearchResults = await UseCase.Execute(SearchQuery);
        }

        [Test]
        public void ItCallsSearchOnGatewayWithSearchString()
        {
            _mock.Verify(mock => mock.SearchAssets(SearchQuery), Times.Once());
        }
    }
}