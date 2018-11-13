using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public class SqlGateway<T, TIndex>:IGateway<T,TIndex> where T: class, IDatabaseEntity<TIndex>
    {
        private readonly IDbConnection _connection;

        public SqlGateway(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<T> CreatAsync(T entity)
        {
            entity.ModifiedDateTime = DateTime.UtcNow;
            await _connection.InsertAsync(entity).ConfigureAwait(false);
            return entity;
        }

        public async Task<T> ReadAsync(TIndex index)
        {
            var entity = await _connection.GetAsync<T>(index).ConfigureAwait(false);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.ModifiedDateTime = DateTime.UtcNow;
            await _connection.UpdateAsync<T>(entity).ConfigureAwait(false);
            
            entity = await ReadAsync(entity.Id).ConfigureAwait(false);
            return entity;
        }

        public async Task<bool> DeleteAsync(TIndex index)
        {
            var rowsAffected = await _connection.DeleteAsync<T>(index).ConfigureAwait(false);
            if (rowsAffected == 1)
                return true;
            if (rowsAffected > 1)
                throw new DeletedTooManyRows();
            return true;
        }

    }
}
