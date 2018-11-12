using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IEntityCreator<T, TIndex> where T : IEntity<TIndex>
    {
        Task<T> CreatAsync(T entity);
    }
}