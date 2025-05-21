using System;
using UnityEngine;

namespace Source.CodeBase.GameplayData.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _figure;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;

        [field: SerializeField] public ItemData Data { get; private set; }
        
        public Vector2 Position => _transform.position;

        private void Init()
        {
            Data.Figure = _figure.sprite;
            Data.Color = _figure.color;
        }

        private void Awake() => Init();

        public void SetSpeed(float value) =>
            _rigidbody.velocity += Vector2.down * value;
    }

    [Serializable]
    public class ItemData
    {
        public Color Color;
        public Sprite Figure;
        public Sprite Content;

        public static bool operator ==(ItemData data1, ItemData data2)
        {
            if (data1 == null || data2 == null)
                return false;

            bool isEquals =
                data1.Color == data2.Color &&
                data1.Content == data2.Content &&
                data1.Figure == data2.Figure;

            return isEquals;
        }

        public static bool operator !=(ItemData data1, ItemData data2)
        {
            return !(data1 == data2);
        }
    }
}