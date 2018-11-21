using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Sql.Postgres;
using PeregrineDb;
using PeregrineDb.Databases;

namespace HomesEngland.Gateway.Sql
{
    public class SqlAssetGateway:IGateway<IAsset, int>, IAssetReader, IAssetCreator, IAssetSearcher
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

        public Task<IList<IAsset>> Search(IAssetSearchQuery searchQueryRequest, CancellationToken cancellationToken)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);
            var sql = @"SELECT * FROM assets a Where a.schemeid = @schemeId";
            IEnumerable<IAsset> results = connection.Query<DapperAsset>(sql, new { schemeid = searchQueryRequest.SchemeId });
            _connection.Close();
            return Task.FromResult((IList<IAsset>)results?.ToList());
        }
    }
}
