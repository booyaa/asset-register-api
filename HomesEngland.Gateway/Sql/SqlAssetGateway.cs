using System;
using System.Data;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using PeregrineDb;
using PeregrineDb.Databases;

namespace HomesEngland.Gateway
{
    public class SqlAssetGateway:IGateway<IAsset, int>, IAssetReader, IAssetCreator
    {
        private readonly IDbConnection _connection;

        public SqlAssetGateway(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IAsset> ReadAsync(int index)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);
            var entity = await connection.GetAsync<DapperAsset>(index).ConfigureAwait(false);
            _connection.Close();
            return entity;
        }

        public async Task<IAsset> CreateAsync(IAsset entity)
        {
            entity.ModifiedDateTime = DateTime.UtcNow;
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);
            entity.Id = await connection.InsertAsync<int>(entity).ConfigureAwait(false);

            _connection.Close();
            return entity;
        }

        public Task<IAsset> UpdateAsync(IAsset entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int index)
        {
            throw new NotImplementedException();
        }
    }
}
