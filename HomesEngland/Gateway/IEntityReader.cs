using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IEntityReader<T, TIndex> where T : IEntity<TIndex>
    {
        Task<T> ReadAsync(TIndex index);
    }
}