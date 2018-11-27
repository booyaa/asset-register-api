using System.Collections.Generic;
using System.Threading.Tasks;
using HomesEngland.UseCase.GetAsset.Models;

namespace HomesEngland.UseCase.GenerateAssets
{
    public interface IConsoleGenerator
    {
        Task<IList<AssetOutputModel>> ProcessAsync(string[] args);
    }
}
