namespace Inventory
{
    public interface IItem
    {
        int Id { get; }
        bool IsSelected { get; set; }
        ItemInfo Info { get; }
    }
}