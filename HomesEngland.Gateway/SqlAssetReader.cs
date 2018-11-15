using System;
using System.Data;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using Dapper;

namespace HomesEngland.Gateway.Assets
{
    public class InMemoryAssetReader:IAssetReader
    {
        private readonly IDbConnection _connection;

        public InMemoryAssetReader(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<IAsset> ReadAsync(int index)
        {
            throw new NotImplementedException();
        }
    }
}
