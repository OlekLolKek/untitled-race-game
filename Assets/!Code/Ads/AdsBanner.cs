using UnityEngine.Advertisements;


namespace Ads
{
    public class AdsBanner : IAdsBanner
    {
        private readonly string _placementID;

        public AdsBanner(string placementID)
        {
            _placementID = placementID;
        }

        public bool IsReady() => Advertisement.IsReady(_placementID);

        public void Show(BannerPosition bannerPosition)
        {
            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Show(_placementID);
        }
    }
}