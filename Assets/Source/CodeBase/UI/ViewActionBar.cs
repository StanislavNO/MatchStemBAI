using System.Collections;
using System.Collections.Generic;
using Source.CodeBase.GameplayData.Items;
using UnityEngine;

namespace Source.CodeBase.UI
{
    public class ViewActionBar : MonoBehaviour
    {
        [SerializeField] private List<Place> _places;
        
        [field: SerializeField] public Vector2 PoolPosition { get; private set; }

        public void Show(IReadOnlyList<Item> items)
        {
            ArrayList tmpItems = new ArrayList();
            tmpItems.Add(1);
        }
    }
}