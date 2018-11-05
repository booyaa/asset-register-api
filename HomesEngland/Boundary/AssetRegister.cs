using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;
using HomesEngland.Boundary.Port;
using HomesEngland.Boundary.UseCase;
using HomesEngland.Gateway;
using HomesEngland.UseCase;

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