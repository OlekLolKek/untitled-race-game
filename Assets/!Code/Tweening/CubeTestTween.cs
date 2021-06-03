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

        private void ComplexTween()
        {
            var sequence = DOTween.Sequence();

            sequence.Append(transform.DOMoveY(_positionX, _duration).SetLoops(_loopsCount).SetEase(Ease.Linear));
            sequence.Insert(0, transform.DOScale(_endScale, _duration));
            sequence.Insert(1, transform.DOJump(Vector3.forward, 5, 5, _duration));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ComplexTween();
            }
        }
    }
}