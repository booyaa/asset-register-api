using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IEntityUpdater<T, TIndex> where T : IEntity<TIndex>
    {
        Task<T> UpdateAsync(T entity);
    }
}