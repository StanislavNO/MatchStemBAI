using System.Collections;
using System.Collections.Generic;
using Source.CodeBase.Configs;
using Source.CodeBase.GameplayData.Environment;
using Source.CodeBase.GameplayData.Items;
using Source.CodeBase.Infrastructure.Services.Factories;
using Source.CodeBase.Infrastructure.Services.Rondomizer;
using UnityEngine;

namespace Source.CodeBase.Logic.Controllers
{
    public class Spawner
    {
        private readonly ItemFactory _factory;
        private readonly Vector3 _spawnPosition;
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly float _spawnDelay;
        private readonly float _startSpeed;

        private List<Item> _items;
        private Coroutine _spawning;

        public Spawner(
            ItemFactory factory,
            SpawnPoint spawnPoint,
            LevelSetting levelSetting)
        {
            _factory = factory;
            _spawnPosition = spawnPoint.Position;
            _coroutineRunner = spawnPoint;
            _items = new List<Item>();

            _spawnDelay = levelSetting.SpawningSettings.SpawnDelaySecond;
            _startSpeed = levelSetting.SpawningSettings.StartSpeedItem;
        }

        public void Run()
        {
            _items = _factory.Get();
            RandomShuffler.Shuffle(_items);

            _spawning = _coroutineRunner.StartCoroutine(Spawn());
        }

        public void Stop() =>
            _coroutineRunner.StopCoroutine(_spawning);

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_spawnDelay);

            foreach (var item in _items)
            {
                item.transform.position = _spawnPosition;
                item.gameObject.SetActive(true);
                item.SetSpeed(_startSpeed);
                yield return wait;
            }
        }
    }
}