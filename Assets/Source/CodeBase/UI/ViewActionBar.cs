using System.Collections.Generic;
using Source.CodeBase.GameplayData.ActionBar;
using Source.CodeBase.GameplayData.Item;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.UI
{
    public class ViewActionBar : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> _places;
        
        private IReadOnlyBar _bar;

        //[Inject]
        private void Init(IReadOnlyBar bar)
        {
            _bar = bar;
        }
        
        public void Show(int placeIndex, Item items)
        {
            
        }
    }
}