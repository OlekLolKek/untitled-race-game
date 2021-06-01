using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace Tweening
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _closePopupButton;
        [SerializeField] private float _duration = 0.3f;
        private Sequence _sequence;

        private void Start()
        {
            _closePopupButton.onClick.AddListener(HidePopup);
        }

        private void OnDestroy()
        {
            _closePopupButton.onClick.RemoveAllListeners();
            transform.DOKill();
            _sequence.Kill();
            _sequence = null;
        }

        public void ShowPopup()
        {
            gameObject.SetActive(true);

            AnimationShow();
        }

        public void HidePopup()
        {
            AnimationHide();
        }

        private void AnimationShow()
        {
            _sequence = DOTween.Sequence();

            _sequence.Insert(0.0f, transform.DOScale(Vector3.one, _duration));
            _sequence.OnComplete(() =>
            {
                _sequence = null;
            });
        }

        private void AnimationHide()
        {
            _sequence = DOTween.Sequence();

            _sequence.Insert(0.0f, transform.DOScale(Vector3.zero, _duration));
            _sequence.OnComplete(() =>
            {
                _sequence = null;
                gameObject.SetActive(false);
            });
        }
    }
}