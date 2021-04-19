using UnityEngine.Advertisements;


namespace Ads
{
    public interface IAdsBanner
    {
        bool IsReady();
        void Show(BannerPosition bannerPosition);
    }
}