using JoostenProductions;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace Ui
{
    public sealed class MainMenuTrailView : MonoBehaviour
    {
        [SerializeField] private float _zPosition;

        private Camera _camera;
        
        public void Init()
        {
            UpdateManager.SubscribeToUpdate(Move);
            _camera = Camera.main;
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            var position = 
                _camera.ScreenToWorldPoint(CrossPlatformInputManager.mousePosition);
            position.z = _zPosition;
            transform.position = position;
        }
    }
}