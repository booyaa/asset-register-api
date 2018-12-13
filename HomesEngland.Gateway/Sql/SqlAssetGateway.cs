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
    public class SqlAssetGateway : IGateway<IAsset, int>, IAssetReader, IAssetCreator, IAssetSearcher, IAssetAggregator
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

        public Task<IPagedResults<IAsset>> Search(IAssetPagedSearchQuery pagedSearchQueryRequest,CancellationToken cancellationToken)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);

            var searchSql = GenerateConditionalPagedSearchSql(pagedSearchQueryRequest);
            var searchObject = new
            {
                schemeid = pagedSearchQueryRequest.SchemeId,
                address = $"%{pagedSearchQueryRequest?.Address}%",
                pageSize = pagedSearchQueryRequest.PageSize,
                offset = pagedSearchQueryRequest.PageSize * (pagedSearchQueryRequest.Page - 1)
            };
            IEnumerable<IAsset> results = connection.Query<DapperAsset>(searchSql, searchObject);
            IPagedResults<IAsset> pagedResults = new PagedResults<IAsset> {Results = results?.ToList()};

            int totalCount = connection.ExecuteScalar<int>(GenerateTotalCountSql(pagedSearchQueryRequest), searchObject);

            pagedResults.TotalCount = totalCount;

            pagedResults.NumberOfPages =
                (int) Math.Ceiling(totalCount / (decimal) pagedSearchQueryRequest.PageSize.Value);

            _connection.Close();
            return Task.FromResult(pagedResults);
        }

        private string GenerateTotalCountSql(IAssetPagedSearchQuery assetPagedSearchQuery)
        {
            var sql = @"SELECT count(id) FROM assets a ";

            IList<string> filteringClauses = new List<string>();
            if (assetPagedSearchQuery.SchemeId.HasValue)
                filteringClauses.Add("a.schemeid = @schemeId ");
            if (!string.IsNullOrEmpty(assetPagedSearchQuery.Address) && !string.IsNullOrWhiteSpace(assetPagedSearchQuery.Address))
                filteringClauses.Add("lower(a.address) LIKE lower(@address) ");

            var sb = new StringBuilder();
            sb.Append(sql);
            for (int i = 0; i < filteringClauses.Count; i++)
            {
                sb.Append(i == 0 ? "WHERE " : "AND ");

                sb.Append(filteringClauses.ElementAtOrDefault(i));
            }

            return sb.ToString();
        }

        private string GenerateConditionalPagedSearchSql(IAssetPagedSearchQuery pagedSearchQueryRequest)
        {
            var sql = GenerateConditionalSearchSql(pagedSearchQueryRequest);

            var sb = new StringBuilder();
            sb.Append(sql);
            sb.Append(" ORDER BY a.schemeid DESC");

            sb.Append(" LIMIT @pageSize OFFSET @offset;");
            return sb.ToString();
        }

        public async Task<IAssetAggregation> Aggregate(IAssetSearchQuery searchRequest, CancellationToken cancellationToken)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);

            var searchObject = new
            {
                schemeid = searchRequest.SchemeId,
                address = $"%{searchRequest?.Address}%",
            };

            var generateUniqueCountSql = GenerateUniqueCountSql(searchRequest);
            int uniqueCount = connection.ExecuteScalar<int>(generateUniqueCountSql, searchObject);

            
            _connection.Close();

            var assetAggregation = new DapperAssetAggregation
            {
                UniqueRecords = uniqueCount,

            };
            return assetAggregation;
        }

        private static string GenerateConditionalSearchSql(IAssetSearchQuery pagedSearchQueryRequest)
        {
            var sql = @"SELECT * FROM assets a ";
            IList<string> filteringClauses = new List<string>();
            if (pagedSearchQueryRequest.SchemeId.HasValue)
                filteringClauses.Add("a.schemeid = @schemeId ");
            if (!string.IsNullOrEmpty(pagedSearchQueryRequest.Address) &&
                !string.IsNullOrWhiteSpace(pagedSearchQueryRequest.Address))
                filteringClauses.Add("lower(a.address) LIKE lower(@address) ");

            var sb = new StringBuilder();
            sb.Append(sql);
            for (int i = 0; i < filteringClauses.Count; i++)
            {
                sb.Append(i == 0 ? "WHERE " : "AND ");

                sb.Append(filteringClauses.ElementAtOrDefault(i));
            }

            return sb.ToString();
        }

        private static string GenerateUniqueCountSql(IAssetSearchQuery assetPagedSearchQuery)
        {
            var sql = @"SELECT COUNT(DISTINCT a.schemeid) as UniqueCount FROM assets a ";

            IList<string> filteringClauses = new List<string>();
            if (assetPagedSearchQuery.SchemeId.HasValue)
                filteringClauses.Add("a.schemeid = @schemeId ");
            if (!string.IsNullOrEmpty(assetPagedSearchQuery.Address) && !string.IsNullOrWhiteSpace(assetPagedSearchQuery.Address))
                filteringClauses.Add("lower(a.address) LIKE lower(@address) ");

            var sb = new StringBuilder();
            sb.Append(sql);
            for (int i = 0; i < filteringClauses.Count; i++)
            {
                sb.Append(i == 0 ? "WHERE " : "AND ");

                sb.Append(filteringClauses.ElementAtOrDefault(i));
            }

            return sb.ToString();
        }
    }
}
