using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            if (entity == null)
                return null;
            entity = new DapperAsset(entity);
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

            var searchSql = GenerateConditionalSearchSql(searchQueryRequest);
            var searchObject = new
            {
                schemeid = searchQueryRequest.SchemeId,
                address = $"%{searchQueryRequest?.Address}%"
            };
            IEnumerable<IAsset> results = connection.Query<DapperAsset>(searchSql, searchObject);
            _connection.Close();
            return Task.FromResult((IList<IAsset>)results?.ToList());
        }

        private static string GenerateConditionalSearchSql(IAssetSearchQuery searchQueryRequest)
        {
            var sql = @"SELECT * FROM assets a ";
            IList<string> filteringClauses = new List<string>();
            if (searchQueryRequest.SchemeId.HasValue)
                filteringClauses.Add("a.schemeid = @schemeId ");
            if (!string.IsNullOrEmpty(searchQueryRequest.Address) && !string.IsNullOrWhiteSpace(searchQueryRequest.Address))
                filteringClauses.Add("lower(a.address) LIKE lower(@address) ");

            var sb = new StringBuilder();
            sb.Append(sql);
            for (int i = 0; i < filteringClauses.Count; i++)
            {
                sb.Append(i == 0 ? "WHERE " : "AND ");

                sb.Append(filteringClauses.ElementAtOrDefault(i));
            }

            sb.Append(" ORDER BY a.schemeid DESC;");
            return sb.ToString();
        }
    }
}
