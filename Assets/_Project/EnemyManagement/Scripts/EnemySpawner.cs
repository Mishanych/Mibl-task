using System.Collections;
using System.Collections.Generic;
using Factory;
using PlayerManagement;
using UnityEngine;

namespace EnemyManagement
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<Enemy> _enemies;

        private RandomSpawnFactory<Enemy> _enemySpawnFactory;
        private List<GameObject> _spawnedObjects = new ();

        private void Awake()
        {
            _enemySpawnFactory = new EnemySpawnFactory<Enemy>();
            StartCoroutine(StartSpawningEnemies());
        }

        private IEnumerator StartSpawningEnemies()
        {
            while (_player.IsAlive)
            {
                foreach (Enemy enemy in _enemies)
                {
                    _spawnedObjects.Add(_enemySpawnFactory.Spawn(enemy));

                    yield return new WaitForSeconds(enemy.EnemySettingsHolder.SpawnSettings.TimeBetweenSpawnsInSeconds);
                }
            }
        }

        private void OnDestroy()
        {
            foreach (var obj in _spawnedObjects)
            {
                Destroy(obj);
            }
        }
    }
}