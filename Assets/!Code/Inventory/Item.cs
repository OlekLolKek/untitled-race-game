namespace Inventory
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public bool IsSelected { get; set; }
        public ItemInfo Info { get; set; }
    }
}