using System;

namespace HomesEngland.Domain
{
    public interface IEntity<TIndex>
    {
        TIndex Id { get; set; }

        DateTime ModifiedDateTime { get; set; }
    }
}