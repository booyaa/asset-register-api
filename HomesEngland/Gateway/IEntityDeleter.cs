using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IEntityDeleter<T, TIndex> where T : IEntity<TIndex>
    {
        Task<bool> DeleteAsync(TIndex index);
    }
}