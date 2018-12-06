using System;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.ImportAssets;
using Main;

namespace HomesEngland.AssetImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var assetRegister = new AssetRegister();
            IConsoleImporter assetImporter = assetRegister.Get<IConsoleImporter>();
            assetImporter.ProcessAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
