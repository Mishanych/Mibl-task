using System.Collections;
using System.Collections.Generic;
using Core.ServiceLocator;
using Factory;
using PlayerManagement;
using UnityEngine;

namespace BombManagement
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _plane;
        [SerializeField] private List<Bomb> _bombs;

        private RandomSpawnFactory<Bomb> _bombSpawnFactory;
        private List<GameObject> _spawnedObjects = new List<GameObject>();

        #region Services

        private IPlayerService _playerInstance;
        private IPlayerService _player
            => _playerInstance ??= Service.Instance.Get<IPlayerService>();

        #endregion

        private void Start()
        {
            _bombSpawnFactory = new BombSpawnFactory();
            StartCoroutine(StartSpawningBombs());
        }

        private void OnDestroy()
        {
            foreach (GameObject spawnedObject in _spawnedObjects)
            {
                Destroy(spawnedObject);
            }
        }

        private IEnumerator StartSpawningBombs()
        {
            while (_player.IsAlive)
            {
                foreach (Bomb bomb in _bombs)
                {
                    _spawnedObjects.Add(_bombSpawnFactory.Spawn(bomb, _plane.position));

                    yield return new WaitForSeconds(bomb.SpawnSettings.TimeBetweenSpawnsInSeconds);
                }
            }
        }
    }
}