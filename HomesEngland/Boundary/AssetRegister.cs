using DependencyInjection;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Impl;
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
            RegisterExportedDependency<IAssetReader, InMemoryAssetReader>();
        }
    }
}