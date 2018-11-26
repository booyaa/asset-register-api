using System.Data;
using DependencyInjection;
using HomesEngland.Domain;
using HomesEngland.Gateway;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.DataGenerator;
using HomesEngland.Gateway.Migrations;
using HomesEngland.Gateway.Sql;
using HomesEngland.Gateway.Sql.Postgres;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Impl;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GenerateAssets.Impl;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Impl;
using HomesEngland.UseCase.SearchAsset.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console.Internal;

namespace Main
{
    public class AssetRegister : DependencyExporter
    {
        private ServiceProvider _serviceProvider;

        protected override void ConstructHiddenDependencies()
        {
            var serviceCollection = new ServiceCollection();
            
            ExportDependencies((type, provider) => serviceCollection.AddTransient(type, _ => provider()));

            ExportTypeDependencies((type, provider) => serviceCollection.AddTransient(type, provider));

            serviceCollection.AddEntityFrameworkNpgsql().AddDbContext<AssetRegisterContext>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
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
            RegisterExportedDependency<IGenerateAssetsUseCase, GenerateAssetsUseCase>();
            RegisterExportedDependency<IConsoleGenerator, ConsoleGenerator>();
            RegisterExportedDependency<IInputParser, InputParser>();
        }

        public override T Get<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
