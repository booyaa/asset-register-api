using System.Threading.Tasks;

namespace HomesEngland.UseCase.GenerateAssets
{
    public interface IConsoleGenerator
    {
        Task ProcessAsync(string[] args);
    }
}
