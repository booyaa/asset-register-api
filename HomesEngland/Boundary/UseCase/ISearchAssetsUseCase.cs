using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomesEngland.Boundary.UseCase
{
    public interface ISearchAssetsUseCase
    {
        Task<Dictionary<string, string>[]> Execute(string query);
    }
}