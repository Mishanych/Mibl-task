using EnemyManagement;
using UnityEngine;

namespace BombManagement
{
    public abstract class Bomb : MonoBehaviour
    {
        [SerializeField ] private SpawnSettings _spawnSettings;

        public SpawnSettings SpawnSettings => _spawnSettings;
    }
}