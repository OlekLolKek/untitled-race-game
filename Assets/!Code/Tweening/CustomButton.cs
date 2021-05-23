using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Tweening
{
    public class CustomButton : Button
    {
        public static string ChangeButtonType => nameof(_buttonAnimationType);
        public static string EaseCurve => nameof(_easeCurve);
        public static string Duration => nameof(_duration);

        [SerializeField] private ButtonAnimationType _buttonAnimationType = ButtonAnimationType.ChangePosition;
        [SerializeField] private Ease _easeCurve = Ease.Linear;
        [SerializeField] private float _duration = 0.6f;

        private Vector3 _minScale = new Vector3(0.9f, 0.9f);
        private RectTransform _rectTransform;
        private float _strength = 30.0f;

        protected override void Awake()
        {
            base.Awake();

            _rectTransform = GetComponent<RectTransform>();
        }

        #region Overrides of Button

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            ActivateAnimation();
        }

        private void ActivateAnimation()
        {
            switch (_buttonAnimationType)
            {
                case ButtonAnimationType.ChangeRotation:
                    _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_easeCurve);
                    break;
                case ButtonAnimationType.ChangePosition:
                    _rectTransform.DOShakeAnchorPos(_duration, Vector2.one * _strength).SetEase(_easeCurve);
                    break;
                case ButtonAnimationType.ChangeScale:
                    var sequence = DOTween.Sequence();
                    sequence.Append(_rectTransform.DOScale(new Vector3(0.9f, 0.9f), _duration).SetEase(_easeCurve));
                    sequence.Append(_rectTransform.DOScale(Vector3.one, _duration).SetEase(_easeCurve));
                    sequence.onComplete += () => sequence.Kill();
                    break;
                default:
                    throw new NotImplementedException(
                        $"{_buttonAnimationType} is not supported in {nameof(ActivateAnimation)}.");
            }
        }

        #endregion
    }
}