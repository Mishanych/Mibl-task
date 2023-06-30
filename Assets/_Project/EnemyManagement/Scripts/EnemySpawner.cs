using System.Collections;
using System.Collections.Generic;
using Core.ServiceLocator;
using Factory;
using PlayerManagement;
using UnityEngine;

namespace EnemyManagement
{
    public class EnemySpawner : MonoBehaviour
    {
        
        [SerializeField] private Transform _plane;
        [SerializeField] private List<Enemy> _enemies;

        private RandomSpawnFactory<Enemy> _enemySpawnFactory;
        private List<GameObject> _spawnedObjects = new ();

        #region Services

        private IPlayerService _playerInstance;
        private IPlayerService _player
            => _playerInstance ??= Service.Instance.Get<IPlayerService>();

        #endregion

        private void Awake()
        {
            _enemySpawnFactory = new EnemySpawnFactory();
            StartCoroutine(StartSpawningEnemies());
        }

        private void OnDestroy()
        {
            foreach (GameObject spawnedObject in _spawnedObjects)
            {
                Destroy(spawnedObject);
            }
        }

        private IEnumerator StartSpawningEnemies()
        {
            while (_player.IsAlive)
            {
                foreach (Enemy enemy in _enemies)
                {
                    _spawnedObjects.Add(_enemySpawnFactory.Spawn(enemy, _plane.position));

                    yield return new WaitForSeconds(enemy.EnemySettingsHolder.SpawnSettings.TimeBetweenSpawnsInSeconds);
                }
            }
        }
    }
}