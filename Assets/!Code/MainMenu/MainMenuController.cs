using System.Linq;
using Ads;
using Garage;
using Inventory;
using Profile;
using Tools;
using UnityEngine;


namespace Ui
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath
        {
            PathResource = "Prefabs/mainMenu"
        };
        private readonly ProfilePlayer _profilePlayer;
        private readonly UnityAdsTools _unityAdsTools;
        private readonly MainMenuTrailController _mainMenuTrailController;
        private readonly ShedController _shedController;
        private readonly MainMenuView _view;
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer,
            UnityAdsTools unityAdsTools)
        {
            _profilePlayer = profilePlayer;
            _unityAdsTools = unityAdsTools;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, EnterGarage);

            _mainMenuTrailController = new MainMenuTrailController();
            AddController(_mainMenuTrailController);

            _shedController = ConfigureShedController(placeForUi, profilePlayer);
            AddController(_shedController);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = 
                Object.Instantiate(
                    ResourceLoader.LoadPrefab(_viewPath), 
                    placeForUi, 
                    false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private ShedController ConfigureShedController(
            Transform placeForUi,
            ProfilePlayer profilePlayer)
        {
            var upgradeItemsConfigCollection
                = ContentDataSourceLoader.LoadUpgradeItemConfigs(new ResourcePath()
                    {PathResource = "DataSource/Upgrade/UpgradeItemConfigDataSource"});

            var upgradeItemsRepository
                = new UpgradeHandlersRepository(upgradeItemsConfigCollection);

            var itemsRepository
                = new ItemsRepository(upgradeItemsConfigCollection.Select(
                    value => value.ItemConfig).ToList());
            var inventoryModel
                = new InventoryModel();
            var inventoryViewPath
                = new ResourcePath {PathResource = $"Prefabs/{nameof(InventoryView)}"};
            var inventoryView
                = ResourceLoader.LoadAndInstantiateObject<InventoryView>(
                    inventoryViewPath, placeForUi, false);
            AddGameObjects(inventoryView.gameObject);
            var inventoryController
                = new InventoryController(itemsRepository, inventoryModel, inventoryView);
            AddController(inventoryController);

            var shedController
                = new ShedController(upgradeItemsRepository, inventoryController, profilePlayer.CurrentCar);
            AddController(shedController);
            
            return shedController;
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game");
        }

        private void EnterGarage()
        {
            _shedController.Enter();
        }
    }
}

