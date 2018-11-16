using System;
using System.Data;
using System.Linq;
using Npgsql;

namespace HomesEngland.Gateway
{
    public class PostgresDatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        /// <summary>
        /// Takes a //postgres://circleci:super-secret@localhost:5432/asset_register_api databaseUrl
        /// </summary>
        /// <param name="databaseUrl"></param>
        /// <returns></returns>
        public IDbConnection Create(string databaseUrl)
        {
            var ngpsqlConnectionString = BuildConnectionStringFromUrl(databaseUrl);

            return new NpgsqlConnection(ngpsqlConnectionString);
        }

        public string BuildConnectionStringFromUrl(string databaseUrl)
        {
            var uri = new Uri(databaseUrl);
            var splitUserInfo = uri.UserInfo.Split(':');
            var server = uri.Host;
            var port = uri.Port;
            var userId = splitUserInfo.ElementAtOrDefault(0);
            var password = splitUserInfo.ElementAtOrDefault(1);
            var database = uri.LocalPath.Substring(1); 
            string ngpsqlConnectionString = $"Server={server};Port={port};User Id={userId};Password={password};Database={database};";
            return ngpsqlConnectionString;
        }
    }
}