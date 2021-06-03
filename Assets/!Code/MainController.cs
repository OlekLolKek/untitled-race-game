using Ads;
using Game;
using Profile;
using Ui;
using UnityEngine;

internal sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly UnityAdsTools _unityAdsTools;
    
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer,
        UnityAdsTools adsTools)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _unityAdsTools = adsTools;
        
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer,
                    _unityAdsTools);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }
}
