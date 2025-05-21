using System;
using System.Collections.Generic;
using System.Linq;
using Source.CodeBase.Configs;
using Source.CodeBase.GameplayData.Items;

namespace Source.CodeBase.GameplayData.ActionBar
{
    public class ActionBarData : IReadOnlyBar
    {
        private const int MATCH_SIZE = 3;

        public event Action OnBarFulled;
        public event Action OnBarMatched;

        private readonly int _maxItems;
        private List<Item> _items;

        public bool CanItemAdd => _items.Count < _maxItems;
        public IReadOnlyList<Item> Items => _items;

        public ActionBarData(LevelSetting levelSetting)
        {
            _items = new List<Item>();
            _maxItems = levelSetting.MaxItemsInBar;
        }

        public void Add(Item item)
        {
            if (CanItemAdd)
                _items.Add(item);
        }

        public void CheckMatch()
        {
            if (_items.Count < MATCH_SIZE)
                return;

            var matchedGroups = _items
                .GroupBy(item => item.Data)
                .Where(group => group.Count() >= 3)
                .ToList();

            if (!matchedGroups.Any())
                return;

            var itemsToRemove = matchedGroups
                .SelectMany(group => group)
                .ToList();

            _items = _items.Except(itemsToRemove).ToList();
            OnBarMatched?.Invoke();
        }
    }
}