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

        private void Start()
        {
            _closePopupButton.onClick.AddListener(HidePopup);
        }

        private void OnDestroy()
        {
            _closePopupButton.onClick.RemoveAllListeners();
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
            var sequence = DOTween.Sequence();

            sequence.Insert(0.0f, transform.DOScale(Vector3.one, _duration));
            sequence.OnComplete(() =>
            {
                sequence = null;
            });
        }

        private void AnimationHide()
        {
            var sequence = DOTween.Sequence();

            sequence.Insert(0.0f, transform.DOScale(Vector3.zero, _duration));
            sequence.OnComplete(() =>
            {
                sequence = null;
                gameObject.SetActive(false);
            });
        }
    }
}