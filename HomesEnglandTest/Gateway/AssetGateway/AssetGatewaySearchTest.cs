using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary;
using HomesEngland.Domain;
using NUnit.Framework;

namespace HomesEnglandTest.Gateway.AssetGateway
{
    [TestFixture]
    public abstract class AssetGatewaySearchTest
    {
        protected abstract IAssetGateway AssetGateway { get; set; }
        protected abstract string SearchQuery { get; }
        protected abstract Asset[] AssetsInGateway { get; }
        protected abstract Asset[] ExpectedGatewaySearchResults { get; }
        private Asset[] GatewaySearchResults { get; set; }
        
        [SetUp]
        public virtual async Task SetUp()
        {
            await AddAssetsToGateway();
            GatewaySearchResults = await AssetGateway.SearchAssets(SearchQuery);
        }
        
        private async Task AddAssetsToGateway()
        {
            foreach (var asset in AssetsInGateway)
            {
                await AssetGateway.AddAsset(asset);
            }
        }

        [Test]
        public void CheckSearchResults()
        {
            for (int i = 0; i < ExpectedGatewaySearchResults.Length; i++)
            {
                Assert.True(GatewaySearchResults.Any(_=>_.Address == ExpectedGatewaySearchResults[i].Address));
                Assert.True(GatewaySearchResults.Any(_=>_.AccountingYear == ExpectedGatewaySearchResults[i].AccountingYear));
                Assert.True(GatewaySearchResults.Any(_=>_.SchemeID == ExpectedGatewaySearchResults[i].SchemeID));
            }
        }
    }
}