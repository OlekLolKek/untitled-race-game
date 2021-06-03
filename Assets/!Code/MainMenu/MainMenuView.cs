using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _garageButton;
            
        public void Init(UnityAction startGame, UnityAction enterGarage)
        {
            _buttonStart.onClick.AddListener(startGame);
            _garageButton.onClick.AddListener(enterGarage);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _garageButton.onClick.RemoveAllListeners();
        }
    }
}

