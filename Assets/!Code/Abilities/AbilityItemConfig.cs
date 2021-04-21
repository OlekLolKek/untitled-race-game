using Inventory;
using UnityEngine;


namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityItem", menuName = "Config/Ability Item")]
    public class AbilityItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private GameObject _view;
        [SerializeField] private AbilityType _type;
        [SerializeField] private float _value;
        
        public ItemConfig ItemConfig => _itemConfig;
        public GameObject View => _view;
        public AbilityType Type => _type;
        public float Value => _value;
        public int ID => _itemConfig.ID;
    }
}