using System.Collections;
using System.Collections.Generic;
using Factory;
using PlayerManagement;
using UnityEngine;

namespace BombManagement
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<Bomb> _bombs;

        private RandomSpawnFactory<Bomb> _bombSpawnFactory;
        private List<GameObject> _spawnedObjects = new ();

        private void Awake()
        {
            _bombSpawnFactory = new BombSpawnFactory<Bomb>();
            StartCoroutine(StartSpawningBombs());
        }

        private IEnumerator StartSpawningBombs()
        {
            while (_player.IsAlive)
            {
                foreach (Bomb bomb in _bombs)
                {
                    _spawnedObjects.Add(_bombSpawnFactory.Spawn(bomb));

                    yield return new WaitForSeconds(bomb.SpawnSettings.TimeBetweenSpawnsInSeconds);
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