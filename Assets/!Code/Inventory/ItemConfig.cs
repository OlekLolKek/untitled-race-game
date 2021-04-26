using UnityEngine;


namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Config/Item")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;

        public int ID => _id;
        public string Title => _title;
        public string Description => _description;
        public Sprite Icon => _icon;
    }
}