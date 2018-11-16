using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HomesEngland.Domain;

namespace HomesEngland.Gateway.Migrations
{
    public class AssetRegisterContext:DbContext
    {
        private string _databaseUrl;
        public AssetRegisterContext(string databaseUrl)
        {
            _databaseUrl = databaseUrl;
        }
        public AssetRegisterContext()
        {
            _databaseUrl = "postgres://postgres:super-secret@db:5432/asset_register_api";
        }
        public DbSet<DapperAsset> Assets { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_databaseUrl);
    }  
}