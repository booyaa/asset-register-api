using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomesEngland.Boundary.UseCase
{
    public interface IGetAssetUseCase
    {
        Task<Dictionary<string,string>> Execute(int id);
    }
}