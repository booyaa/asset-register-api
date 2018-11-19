using System.Data;
using System.Threading.Tasks;
using Dapper;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;

namespace HomesEngland.Gateway
{
    public class SqlAssetReader:IAssetReader
    {
        private readonly IDbConnection _connection;

        public SqlAssetReader(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IAsset> ReadAsync(int index)
        {
            var entity = await _connection.GetAsync<DapperAsset>(index).ConfigureAwait(false);
            return entity;
        }
    }
}
