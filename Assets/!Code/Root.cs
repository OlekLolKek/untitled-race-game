using Ads;
using Analytic;
using Profile;
using UnityEngine;


internal sealed class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private float _speedCar = 15.0f;
    [SerializeField] private UnityAdsTools _ads;

    private MainController _mainController;

    private void Awake()
    {
        UnityAnalyticTools unityAnalyticTools = new UnityAnalyticTools();
        ProfilePlayer profilePlayer = new ProfilePlayer(_speedCar, unityAnalyticTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _ads);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
