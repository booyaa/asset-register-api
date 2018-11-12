using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using HomesEngland.Boundary.Port;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public class AssetGateway:IAssetGateway
    {
        private readonly IDbConnection _connection;

        public AssetGateway(IDbConnection connection)
        {
            _connection = connection;
        }
        public Task<int> AddAsset(Asset asset)
        {
            throw new NotImplementedException();
        }

        public Task<Asset> GetAsset(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Asset[]> GetAssets(int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<Asset[]> SearchAssets(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
