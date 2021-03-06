using Abilities;
using Game.InputLogic;
using Game.TapeBackground;
using Inventory;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class GameController : BaseController
    {
        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            InventoryModel inventoryModel = new InventoryModel();

            TapeBackgroundController tapeBackgroundController =
                new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            
            AddController(tapeBackgroundController);
            
            InputGameController inputGameController = 
                new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            
            AddController(inputGameController);
            
            CarController carController = 
                new CarController();
            
            AddController(carController);

            var abilityController = ConfigureAbilityController(placeForUi, carController);
        }

        private IAbilitiesController ConfigureAbilityController(
            Transform placeForUi,
            IAbilityActivator abilityActivator)
        {
            var abilityItemsConfigCollection
                = ContentDataSourceLoader.LoadAbilityItemConfigs(new ResourcePath
                    {PathResource = "DataSource/Ability/AbilityItemConfigDataSource"});
            var abilityRepository
                = new AbilityRepository(abilityItemsConfigCollection);
            var abilityCollectionViewPath
                = new ResourcePath {PathResource = $"Prefabs/{nameof(AbilityCollectionView)}"};
            var abilityCollectionView
                = ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(
                    abilityCollectionViewPath, 
                    placeForUi,
                    false);
            AddGameObjects(abilityCollectionView.gameObject);

            var inventoryModel = new InventoryModel();
            var abilitiesController = new AbilitiesController(
                abilityRepository,
                inventoryModel,
                abilityCollectionView,
                abilityActivator);

            return abilitiesController;
        }
    }
}

