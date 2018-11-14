using System.Data;
using System.Data.SqlClient;
using DependencyInjection;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Impl;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Impl;
using Npgsql;

namespace HomesEngland.Boundary
{    
    public class AssetRegister : DependencyExporter
    {
        protected override void ConstructHiddenDependencies()
        {
            
        }

        protected override void RegisterAllExportedDependencies()
        {
            RegisterExportedDependency<IDbConnection>(() => new NpgsqlConnection("Server=asset-register-db.postgres.database.azure.com;Database={your_database};Port=5432;User Id=assetregister@asset-register-db;Password={your_password};SSL=true;SslMode=Require;"));
            RegisterExportedDependency<IGetAssetUseCase, GetAssetUseCase>();
            RegisterExportedDependency<IAssetReader, SqlAssetReader>();
            
        }
    }
}