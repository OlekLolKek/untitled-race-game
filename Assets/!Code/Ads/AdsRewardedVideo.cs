using UnityEngine.Advertisements;


namespace Ads
{
    public class AdsRewardedVideo : IAdsRewardedVideo
    {
        private readonly string _placementID;

        public AdsRewardedVideo(string placementID)
        {
            _placementID = placementID;
        }

        public bool IsReady() => Advertisement.IsReady(_placementID);
        
        public void Show()
        {
            ShowOptions options = new ShowOptions();
            Advertisement.Show(_placementID, options);
        }
    }
}