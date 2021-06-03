using System;


namespace Ads
{
    public interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}