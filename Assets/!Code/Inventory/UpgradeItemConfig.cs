using UnityEngine;


namespace Inventory
{
    [CreateAssetMenu(fileName = "UpgradeItem", menuName = "Config/Upgrade Item", order = 0)]
    public class UpgradeItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private UpgradeType _type;
        [SerializeField] private float _value;

        public int ID => _itemConfig.ID;
        public ItemConfig ItemConfig => _itemConfig;
        public UpgradeType Type => _type;
        public float Value => _value;
    }
}