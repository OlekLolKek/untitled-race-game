using System.Collections.Generic;


namespace Inventory
{
    public interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}