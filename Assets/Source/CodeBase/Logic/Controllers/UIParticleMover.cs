using System;
using DG.Tweening;
using UnityEngine;

namespace Source.CodeBase.Logic.Controllers
{
    public class UIParticleMover : MonoBehaviour
    {
        [SerializeField] private RectTransform _particlePrefab;
        [SerializeField] private Transform _canvas;
        [SerializeField] private float _moveDuration = 1f;
        [SerializeField] private Ease _easeType = Ease.OutQuad;

        public void Show(Vector2 startPosition, Vector2 endPosition, Action onComplete)
        {
            RectTransform particle = Instantiate(
                _particlePrefab,
                startPosition,
                Quaternion.identity,
                _canvas
            );

            particle.anchoredPosition = startPosition;
            
            var sequence = DOTween.Sequence();
            sequence.Append(particle.DOAnchorPos(endPosition, _moveDuration).SetEase(_easeType));
            sequence.OnComplete(() => Destroy(particle.gameObject));
            sequence.OnKill(() => {
                if (particle != null) 
                    Destroy(particle.gameObject);
                
                onComplete?.Invoke();
            });
        }
    }
}