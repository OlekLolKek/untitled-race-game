using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


namespace Bundles
{
    public class LoadWindowView : AssetBundleViewBase
    {
        [SerializeField] private AssetReference _loadPrefab;
        [SerializeField] private RectTransform _mountSpawnTransform;
        [SerializeField] private Button _loadAssetsButton;
        [SerializeField] private Button _spawnAssetsButton;

        private List<AsyncOperationHandle<GameObject>> _addressablePrefabs =
            new List<AsyncOperationHandle<GameObject>>();

        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAsset);
            _spawnAssetsButton.onClick.AddListener(CreateAddressablesPrefab);
        }

        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();
            
            foreach (var addressablePrefab in _addressablePrefabs)
            {
                Addressables.ReleaseInstance(addressablePrefab);
            }
            
            _addressablePrefabs.Clear();
        }

        private void LoadAsset()
        {
            _loadAssetsButton.interactable = false;

            StartCoroutine(DownloadAndSetAssetBundle());
        }

        private void CreateAddressablesPrefab()
        {
            var addressablePrefab = Addressables.InstantiateAsync(_loadPrefab, _mountSpawnTransform);
            _addressablePrefabs.Add(addressablePrefab);
        }
    }
}