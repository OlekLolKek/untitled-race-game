using System.Collections.Generic;


namespace Garage
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey, TValue> Collection { get; }
    }
}