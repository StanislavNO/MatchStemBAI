using System.Collections.Generic;
using Source.CodeBase.Configs;
using Source.CodeBase.GameplayData.Items;
using UnityEngine;

namespace Source.CodeBase.Infrastructure.Services.Factories
{
    public class ItemFactory
    {
        private const int MIN_ITEMS = 3;
        
        private readonly IReadOnlyList<Item> _prefabs;
        private readonly int _maxItems;
        private readonly GameObject _itemsParent;
        
        public ItemFactory(LevelSetting levelSetting)
        {
            _prefabs = levelSetting.Bundle.Prefabs;
            _maxItems = levelSetting.SpawningSettings.MaxItems;
            _itemsParent = new GameObject(nameof(_itemsParent));
        }
        
        public List<Item> Get()
        {
            var result = new List<Item>();
            int itemCounter = 0;
            int currentItemIndex = 0;

            while (result.Count + MIN_ITEMS <= _maxItems)
            {
                itemCounter++;
                var item = Create(_prefabs[currentItemIndex]);
                result.Add(item);
                
                if (itemCounter >= MIN_ITEMS)
                {
                    itemCounter = 0;
                    currentItemIndex++;
                    
                    if(currentItemIndex >= _prefabs.Count)
                        currentItemIndex = 0;
                }
            }
            
            return result;
        }

        private Item Create(Item prefab)
        { 
            prefab.gameObject.SetActive(false);
            return Object.Instantiate(prefab, _itemsParent.transform);
        } 
    }
}