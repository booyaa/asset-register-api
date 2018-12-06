using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.ImportAssets
{
    public interface IConsoleImporter
    {
        Task<IList<AssetOutputModel>> ProcessAsync(string[] args);
    }
}
