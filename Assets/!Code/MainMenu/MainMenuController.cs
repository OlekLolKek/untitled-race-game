using Ads;
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
        private readonly MainMenuView _view;
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer,
            UnityAdsTools unityAdsTools)
        {
            _profilePlayer = profilePlayer;
            _unityAdsTools = unityAdsTools;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);

            _mainMenuTrailController = new MainMenuTrailController();
            AddController(_mainMenuTrailController);
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

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game");
        }
    }
}

