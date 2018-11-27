using HomesEngland.UseCase.GenerateAssets.Models;

namespace HomesEngland.UseCase.GenerateAssets
{
    public interface IInputParser
    {
        GenerateAssetsRequest Parse(string[] args);
    }
}
