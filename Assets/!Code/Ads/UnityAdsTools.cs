using System;
using UnityEngine;
using UnityEngine.Advertisements;


namespace Ads
{
    public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
        private string _gameID = "4093201";
        private string _rewardPlace = "rewardAds";
        private string _interstitialPlace = "Interstitial_Android";

        private Action _callbackSuccessShowVideo;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            Advertisement.Initialize(_gameID, true);
        }

        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Show(_interstitialPlace);
        }

        public void ShowVideo(Action successShow)
        {
            _callbackSuccessShowVideo = successShow;
            Advertisement.Show(_rewardPlace);
        }

        public void OnUnityAdsReady(string placementId)
        {
        }

        public void OnUnityAdsDidError(string message)
        {
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
            {
                _callbackSuccessShowVideo?.Invoke();
            }
        }
    }
}