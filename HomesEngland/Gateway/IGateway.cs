using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IGateway<T, TIndex>: 
        IEntityCreator<T, TIndex>, 
        IEntityReader<T, TIndex>,
        IEntityUpdater<T, TIndex>,
        IEntityDeleter<T, TIndex> 
        where T : class, IEntity<TIndex>
    {

    }
}