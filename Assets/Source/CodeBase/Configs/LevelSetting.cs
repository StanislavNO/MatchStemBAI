using System;
using System.Collections.Generic;
using Source.CodeBase.GameplayData.Items;
using UnityEngine;

namespace Source.CodeBase.Configs
{
    [CreateAssetMenu(fileName = "LevelSetting", menuName = "LevelSetting")]
    public class LevelSetting : ScriptableObject
    {
        [field: SerializeField] public int MaxItemsInBar { get; private set; } = 7;
        [field: SerializeField] public SpawningSettings SpawningSettings { get; private set; }
        [field: SerializeField] public Bundle Bundle { get; private set; }
    }

    [CreateAssetMenu(fileName = "PrefabsBundle", menuName = "PrefabsBundle")]
    public class Bundle : ScriptableObject
    {
        [field: SerializeField] public List<Item> Prefabs { get; private set; }
    }

    [Serializable]
    public class SpawningSettings
    {
        [field: SerializeField] public float SpawnDelaySecond { get; private set; }
        [field: SerializeField] public int MaxItems { get; private set; }
        [field: SerializeField] public float StartSpeedItem { get; private set; }
    }
}