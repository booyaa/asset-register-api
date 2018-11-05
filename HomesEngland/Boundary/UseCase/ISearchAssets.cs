using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomesEngland.Boundary.UseCase
{
    public interface ISearchAssets : IUseCaseTask<string, Dictionary<string, string>[]>
    {
        
    }
}