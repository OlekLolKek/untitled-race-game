using UnityEngine;


namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "Config/AbilityItemConfigDataSource", order = 0)]
    public class AbilityItemConfigDataSource : ScriptableObject
    {
        private AbilityItemConfig[] _itemConfigs;
        
        public AbilityItemConfig[] ItemConfigs => _itemConfigs;
    }
}