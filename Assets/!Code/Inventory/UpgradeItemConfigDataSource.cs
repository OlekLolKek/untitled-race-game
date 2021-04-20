using UnityEngine;


namespace Inventory
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", 
        menuName = "Config/UpgradeItemConfigDataSource")]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] _itemConfigs;

        public UpgradeItemConfig[] ItemConfigs => _itemConfigs;
    }
}