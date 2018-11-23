using System.Data;
using DependencyInjection;
using HomesEngland.Domain;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Migrations;
using HomesEngland.Gateway.Sql;
using HomesEngland.Gateway.Sql.Postgres;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Impl;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Impl;
using HomesEngland.UseCase.SearchAsset;
using HomesEngland.UseCase.SearchAsset.Impl;
using InMemoryAssetReader = HomesEngland.Gateway.InMemory.InMemoryAssetReader;

namespace Main
{
    public class AssetRegister : DependencyExporter
    {
        protected override void ConstructHiddenDependencies()
        {
        }

        protected override void RegisterAllExportedDependencies()
        {
            var databaseUrl = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            RegisterExportedDependency<IDatabaseConnectionStringFormatter, PostgresDatabaseConnectionStringFormatter>();
            RegisterExportedDependency<IDatabaseConnectionFactory, PostgresDatabaseConnectionFactory>();
            RegisterExportedDependency<IDbConnection>(()=> new PostgresDatabaseConnectionFactory(new PostgresDatabaseConnectionStringFormatter()).Create(databaseUrl));
            RegisterExportedDependency<IGetAssetUseCase, GetAssetUseCase>();
            RegisterExportedDependency<IAssetReader, SqlAssetGateway>();
            RegisterExportedDependency<AssetRegisterContext>(()=> new AssetRegisterContext(databaseUrl));
            RegisterExportedDependency<ISearchAssetUseCase, SearchAssetUseCase>();
            RegisterExportedDependency<IAssetSearcher, SqlAssetGateway>();
            RegisterExportedDependency<IAssetCreator, SqlAssetGateway>();
            RegisterExportedDependency<IGateway<IAsset, int>, SqlAssetGateway>();
            RegisterExportedDependency<ICreateAssetUseCase, CreateAssetUseCase>();
        }
    }
}
