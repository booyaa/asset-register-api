using System;
using System.Data;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using Dapper;

namespace HomesEngland.Gateway.Impl
{
    public class SqlAssetReader:IAssetReader
    {
        private readonly IDbConnection _connection;

        public SqlAssetReader(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Asset> ReadAsync(int index)
        {
            var entity = await _connection.GetAsync<Asset>(index).ConfigureAwait(false);
            return entity;
        }
    }
}
