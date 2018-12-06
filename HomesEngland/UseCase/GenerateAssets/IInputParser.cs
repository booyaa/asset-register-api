using HomesEngland.UseCase.GenerateAssets.Models;

namespace HomesEngland.UseCase.GenerateAssets
{
    public interface IInputParser<T>
    {
        T Parse(string[] args);
    }
}
