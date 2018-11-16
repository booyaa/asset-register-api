using System;
using System.Data;
using System.Linq;
using Npgsql;

namespace HomesEngland.Gateway
{
    public class PostgresDatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        public IDbConnection Create(string connectionString)
        {
            var uri = new Uri(connectionString);
            var splitUserInfo = uri.UserInfo.Split(':');
            var server = uri.Host;
            var port = uri.Port;
            var userId = splitUserInfo.ElementAtOrDefault(0);
            var password = splitUserInfo.ElementAtOrDefault(1);
            var database = uri.LocalPath.Substring(1);

            string connstring = $"Server={server};Port={port};User Id={userId};Password={password};Database={database};";

            return new NpgsqlConnection(connstring);
        }
    }
}