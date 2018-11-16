using System.Data;
using DependencyInjection;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Impl;
using Npgsql;

namespace Main
{
    public class AssetRegister : DependencyExporter
    {
        protected override void ConstructHiddenDependencies()
        {
            
        }

        protected override void RegisterAllExportedDependencies()
        {
            var connectionString = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            RegisterExportedDependency<IDatabaseConnectionFactory, PostgresDatabaseConnectionFactory>();
            RegisterExportedDependency<IDbConnection>(() => new PostgresDatabaseConnectionFactory().Create(connectionString));
            RegisterExportedDependency<IGetAssetUseCase, GetAssetUseCase>();
            RegisterExportedDependency<IAssetReader, SqlAssetReader>();
            
        }
    }
}