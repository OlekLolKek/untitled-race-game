using UnityEngine.Advertisements;


namespace Ads
{
    public class AdsVideo : IAdsVideo
    {
        private readonly string _placementID;

        public AdsVideo(string placementID)
        {
            _placementID = placementID;
        }

        public bool IsReady() => Advertisement.IsReady(_placementID);

        public void Show()
        {
            Advertisement.Show(_placementID);
        }
    }
}