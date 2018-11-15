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
            //postgres://u1gkqgfiyblvhxa7:TbSMnjtd7EFm2BC1YObfeQrWXD5ftTQ4@rdsbroker-b85444a7-5561-4f75-81da-f8c82d5c5815.c7uewwm9qebj.eu-west-1.rds.amazonaws.com:5432/rdsbroker_b85444a7_5561_4f75_81da_f8c82d5c5815
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