using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


namespace Bundles
{
    public class AssetBundleViewBase : MonoBehaviour
    {
        private const string URL_ASSET_BUNDLE_SPRITES = "https://drive.google.com/uc?export=download&id=148jhmdoDKiVekz7DrmSEdKALwN0PJh70";
        private const string URL_ASSET_BUNDLE_AUDIO = "https://drive.google.com/uc?export=download&id=1kBTqE_hPNWtM_ySA4Y4NDnJCC-Bqerm4";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundles;
        [SerializeField] private DataAudioBundle[] _dataAudioBundles;

        private AssetBundle _spritesAssetBundle;
        private AssetBundle _audioAssetBundle;

        protected IEnumerator DownloadAndSetAssetBundle()
        {
            yield return GetSpritesAssetBundle();
            yield return GetAudioAssetBundle();

            if (_spritesAssetBundle == null || _audioAssetBundle == null)
            {
                Debug.LogError($"AssetBundle {_audioAssetBundle} failed to load.");
                yield break;
            }

            SetDownloadAssets();
            yield return null;
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(URL_ASSET_BUNDLE_SPRITES);

            yield return request.SendWebRequest();

            while (!request.isDone)
            {
                yield return null;
            }

            StateRequest(request, ref _spritesAssetBundle);

            yield return null;
        }

        private IEnumerator GetAudioAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(URL_ASSET_BUNDLE_AUDIO);

            yield return request.SendWebRequest();

            while (!request.isDone)
            {
                yield return null;
            }

            StateRequest(request, ref _audioAssetBundle);
            yield return null;
        }

        private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                print("Complete");
            }
            else
            {
                print(request.error);
            }
        }

        private void SetDownloadAssets()
        {
            foreach (var data in _dataSpriteBundles)
            {
                data.Image.sprite = _spritesAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);
            }

            foreach (var data in _dataAudioBundles)
            {
                data.AudioSource.clip = _audioAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
                data.AudioSource.Play();
            }
        }
    }
}