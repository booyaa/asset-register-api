using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomesEngland.Boundary.UseCase
{
    public interface IGetAssets : IUseCaseTask<int[], Dictionary<string, string>[]>
    {
        
    }
}