using PlayerManagement;
using UnityEngine;

namespace EnemyManagement
{
    [CreateAssetMenu(fileName = "EnemySettingsHolder", menuName = "ScriptableObjects/Settings/EnemySettingsHolder")]
    public class EnemySettingsHolder : ScriptableObject
    {
        [SerializeField] private string _enemyName;
        [SerializeField] private WalkSettings _walkSettings;
        [SerializeField] private SpawnSettings _spawnSettings;

        public string EnemyName => _enemyName;
        public WalkSettings WalkSettings => _walkSettings;
        public SpawnSettings SpawnSettings => _spawnSettings;
    }
}