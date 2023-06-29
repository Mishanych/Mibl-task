using UnityEngine;

namespace EnemyManagement
{
    [CreateAssetMenu(fileName = "SpawnSettings", menuName = "ScriptableObjects/EnemySettings/SpawnSettings")]
    public class SpawnSettings : ScriptableObject
    {
        [SerializeField] private float _timeBetweenSpawnsInSeconds;

        public float TimeBetweenSpawnsInSeconds => _timeBetweenSpawnsInSeconds;
    }
}