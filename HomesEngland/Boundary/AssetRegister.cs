using System;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Gateway;
using HomesEngland.UseCase;
using DependencyInjection;
using HomesEngland.UseCase.Assets;

namespace HomesEngland.Boundary
{    
    public class AssetRegister : DependencyExporter
    {
        private volatile IAssetGateway _assetGateway;

        [Obsolete("Use a use case directly instead.")]
        public IAssetGateway _AssetGateway() => _assetGateway;

        protected override void ConstructHiddenDependencies()
        {
            _assetGateway = new InMemoryAsset();
        }

        protected override void RegisterAllExportedDependencies()
        {
            RegisterExportedDependency<IGetAsset>(() => new GetAsset(_assetGateway));
            RegisterExportedDependency<IGetAssets>(() => new GetAssets(_assetGateway));
            RegisterExportedDependency<ISearchAssets>(() => new SearchAssets(_assetGateway));
        }

    }
}