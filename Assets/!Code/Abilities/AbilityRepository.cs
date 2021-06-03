using System.Collections.Generic;
using Garage;


namespace Abilities
{
    public class AbilityRepository : IRepository<int, IAbility>
    {
        private readonly Dictionary<int, IAbility> _abilityMapById
            = new Dictionary<int, IAbility>();

        public AbilityRepository(
            List<AbilityItemConfig> itemConfigs)
        {
            PopulateItems(ref _abilityMapById, itemConfigs);
        }

        private void PopulateItems(
            ref Dictionary<int, IAbility> upgradeHandlersMapByType,
            List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (!upgradeHandlersMapByType.ContainsKey(config.ID))
                {
                    upgradeHandlersMapByType.Add(config.ID, CreateAbilityByType(config));
                }
            }
        }

        private IAbility CreateAbilityByType(AbilityItemConfig config)
        {
            switch (config.Type)
            {
                case AbilityType.Gun:
                    return new GunAbility(config);
                default:
                    return StubAbility.Default;
            }
        }
        
        public IReadOnlyDictionary<int, IAbility> Collection { get; }
    }
}