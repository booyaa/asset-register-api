using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomesEngland.Boundary.Port;
using HomesEngland.Domain;
using HomesEngland.Exception;
using NUnit.Framework;

namespace HomesEnglandTest.Gateway.AssetGateway
{
    [TestFixture]
    public abstract class AssetGatewayTest
    {
        protected abstract IAssetGateway AssetGateway { get; set; }
        
        [Test]
        public void GatewayHasAddAssetMethod()
        {
            Assert.DoesNotThrowAsync(async ()=>await AssetGateway.AddAsset(new Asset()));
        }
        
        [Test]
        public void GetAssetWithThrowNoAssetExceptionIfIdIsInvalid()
        {
            Assert.ThrowsAsync<NoAssetException>(async () => await AssetGateway.GetAsset(-1));
            Assert.ThrowsAsync<NoAssetException>(async () => await AssetGateway.GetAsset(0));
            Assert.ThrowsAsync<NoAssetException>(async () => await AssetGateway.GetAsset(21));
        }
        
        [Test]
        public async Task AddAssetReturnsAssetId()
        {
            int assetId = await AssetGateway.AddAsset(new Asset());
            Assert.True(assetId == 0);
        }
        
        [Test]
        public async Task AddAssetReturnsAssetFromId()
        {
            string address = new Guid().ToString();
            string schemaID = new Guid().ToString();
            string accountingYear = new Guid().ToString();
            Asset assetToAdd = new Asset()
            {
                Address = address,
                SchemeId = schemaID,
                AccountingYear = accountingYear
            };
            int assetId = await AssetGateway.AddAsset(assetToAdd);
            Asset returnedAsset = await AssetGateway.GetAsset(assetId);
            Assert.True((string) returnedAsset.Address == address);
            Assert.True((string) returnedAsset.SchemeId == schemaID);
            Assert.True((string) returnedAsset.AccountingYear == accountingYear);
        }


        [Test]
        public async Task GetItemsFindsCorrectAssetsFromIDs()
        {
            Dictionary<int,Asset> addedAssets = new Dictionary<int, Asset>();
            for (int i = 0; i < 10; i++)
            {
                string address = new Guid().ToString();
                string schemaID = new Guid().ToString();
                string accountingYear = new Guid().ToString();
                Asset assetToAdd = new Asset()
                {
                    Address = address,
                    SchemeId = schemaID,
                    AccountingYear = accountingYear
                };
                int assetId = await AssetGateway.AddAsset(assetToAdd);
                addedAssets.Add(assetId,assetToAdd);
            }

            Asset[] returnedAssets = await AssetGateway.GetAssets(addedAssets.Keys.ToArray());

            for (int i = 0; i < returnedAssets.Length; i++)
            {
                Assert.True(addedAssets.Values.Any(_ => _.Address == returnedAssets[i].Address));
                Assert.True(addedAssets.Values.Any(_ => _.SchemeId == returnedAssets[i].SchemeId));
                Assert.True(addedAssets.Values.Any(_=> _.AccountingYear == returnedAssets[i].AccountingYear));
            }
        }
       
        
        [Test]
        public async Task AddAssetReturnsSequentialIDs()
        {
            for (int i = 0; i < 10; i++)
            {
                int assetId = await AssetGateway.AddAsset(new Asset());
                Assert.True(assetId == i);
            }
        }    
        
        [Test]
        public async Task AddAssetReturnsCorrectAssetsSequentially()
        {
            Dictionary<int,string> addresses = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                string address = new Guid().ToString();
                addresses.Add(i,address);
                await AssetGateway.AddAsset(new Asset(){Address = address});
            }
            
            for (int i = 0; i < 10; i++)
            {
                Asset asset = await AssetGateway.GetAsset(i);
                Assert.True(asset.Address == addresses[i]);
            }
        }
    }
}