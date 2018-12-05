using System;
using HomesEngland.UseCase.GenerateAssets;
using Main;

namespace HomesEngland.AssetImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var assetRegister = new AssetRegister();
            IAssetImporter assetImporter = assetRegister.Get<IAssetImporter>();
            assetImporter.ProcessAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
