using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IDatabaseEntityAggregator<T, TIndex, TSearch, TResponse> where T : IDatabaseEntity<TIndex>
    {
        Task<TResponse> Aggregate(TSearch searchRequest, CancellationToken cancellationToken);
    }
}
