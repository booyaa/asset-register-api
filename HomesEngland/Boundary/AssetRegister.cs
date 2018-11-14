using HomesEngland.Boundary.UseCase;
using HomesEngland.UseCase;
using DependencyInjection;
using HomesEngland.Domain;
using HomesEngland.Gateway;
using HomesEngland.UseCase.GetAsset;
using HomesEngland.UseCase.GetAsset.Impl;

namespace HomesEngland.Boundary
{    
    public class AssetRegister : DependencyExporter
    {
        protected override void ConstructHiddenDependencies()
        {
            
        }

        protected override void RegisterAllExportedDependencies()
        {
            RegisterExportedDependency<IGetAssetUseCase, GetAssetUseCase>();
            RegisterExportedDependency<IAssetReader, SqlGateway<Asset,int>>();
        }
    }
}