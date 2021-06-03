using UnityEngine;
using UnityEngine.Advertisements;


namespace Ads
{
    public class UnityAdsListener : IUnityAdsListener
    {
        private string _myPlacementId;
        private bool _adsAreReady;

        public bool AdsAreReady => _adsAreReady;
        
        public UnityAdsListener(string myPlacementId)
        {
            _myPlacementId = myPlacementId;
        }
        
        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                    Debug.LogWarning("Finished");
                    break;
                
                case ShowResult.Skipped:
                    Debug.LogWarning("Skipped");
                    break;
                
                case ShowResult.Failed:
                    Debug.LogWarning("Failed");
                    break;
            }
        }
        
        public void OnUnityAdsReady(string placementId)
        {
            if (placementId != _myPlacementId) return;

            _adsAreReady = true;
        }

        public void OnUnityAdsDidError(string message)
        {
            Debug.LogError($"Error: {message}");
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            Debug.Log($"Ad started: {placementId}");
        }
    }
}