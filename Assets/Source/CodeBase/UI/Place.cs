using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Source.CodeBase.UI
{
    public class Place : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Image _figure;
        [SerializeField] private Image _content;
        [SerializeField] private Image _background;

        public void Init(Sprite figure, Sprite content, Color color)
        {
            _figure.sprite = figure;
            _content.sprite = content;
            _background.color = color;
        }

        public void Hide()
        {
            Vector3 startScale = _transform.localScale;
            _transform.DOScale(0f, 0.3f).SetEase(Ease.OutBounce);
            gameObject.SetActive(false);
            _transform.localScale = startScale;
        }
    }
}