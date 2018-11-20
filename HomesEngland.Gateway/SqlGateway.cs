﻿using System;
using System.Data;
using System.Threading.Tasks;

using HomesEngland.Domain;
using HomesEngland.Gateway.Exceptions;
using PeregrineDb;
using PeregrineDb.Databases;
using PeregrineDb.Dialects.Postgres;
using PeregrineDb.Schema;

namespace HomesEngland.Gateway
{
    public class SqlGateway<T, TIndex> : IGateway<T, TIndex> where T : class, IDatabaseEntity<TIndex>
    {
        private readonly IDbConnection _connection;

        public SqlGateway(IDbConnection connection)
        {
            _connection = connection;
        }

        public class PascalCaseColumnNameFactory : IColumnNameFactory
        {
            public string GetColumnName(PropertySchema property)
            {
                return property.Name;
            }
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.ModifiedDateTime = DateTime.UtcNow;
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);
            var index = await connection.InsertAsync<TIndex>(entity).ConfigureAwait(false);
            entity.Id = index;

            //await _connection.(entity).ConfigureAwait(false);
            _connection.Close();
            return entity;
        }

        public async Task<T> ReadAsync(TIndex index)
        {
            if(_connection.State != ConnectionState.Open)
                _connection.Open();
            var config = PeregrineConfig.Postgres.WithColumnNameFactory(new PascalCaseColumnNameFactory());
            IDatabaseConnection connection = new DefaultDatabase(_connection, config);
            Console.WriteLine(index);
            Console.WriteLine("MEOWMEOW");
            Console.WriteLine(typeof(T));
            var entity = await connection.GetAsync<T>(index).ConfigureAwait(false);
            Console.WriteLine("WOOFWOOF");
            _connection.Close();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
            //entity.ModifiedDateTime = DateTime.UtcNow;
            //await _connection.UpdateAsync<T>(entity).ConfigureAwait(false);

            entity = await ReadAsync(entity.Id).ConfigureAwait(false);
            return entity;
        }

        public async Task<bool> DeleteAsync(TIndex index)
        {
            throw new NotImplementedException();
            //var rowsAffected = await _connection.DeleteAsync<T>(index).ConfigureAwait(false);
            //if (rowsAffected == 1)
            //    return true;
            //if (rowsAffected > 1)
            //    throw new DeletedTooManyRows();
            //return true;
        }

    }
}
