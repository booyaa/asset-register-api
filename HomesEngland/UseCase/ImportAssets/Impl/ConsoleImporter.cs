using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.ImportAssets.Impl
{
    public class ConsoleImporter : IConsoleImporter
    {
        public Task<IList<AssetOutputModel>> ProcessAsync(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
