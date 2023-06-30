using UnityEngine;

namespace EnemyManagement
{
    [CreateAssetMenu(fileName = "SpawnSettings", menuName = "ScriptableObjects/EnemySettings/SpawnSettings")]
    public class SpawnSettings : ScriptableObject
    {
        [SerializeField] private float _timeBetweenSpawnsInSeconds;
        [SerializeField] private float _spawnedRadius;

        public float TimeBetweenSpawnsInSeconds => _timeBetweenSpawnsInSeconds;
        public float SpawnedRadius => _spawnedRadius;
    }
}