using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace Tweening
{
    [RequireComponent(typeof(Renderer))]
    public class CubeTestTween : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _loopsCount;
        [SerializeField] private float _positionX;
        [SerializeField] private float _endScale;
        private Sequence _sequence;

        private void ComplexTween()
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(transform.DOMoveY(_positionX, _duration).SetLoops(_loopsCount).SetEase(Ease.Linear));
            _sequence.Insert(0, transform.DOScale(_endScale, _duration));
            _sequence.Insert(1, transform.DOJump(Vector3.forward, 5, 5, _duration));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ComplexTween();
            }
        }

        private void OnDestroy()
        {
            _sequence.Kill();
            _sequence = null;
            transform.DOKill();
        }
    }
}