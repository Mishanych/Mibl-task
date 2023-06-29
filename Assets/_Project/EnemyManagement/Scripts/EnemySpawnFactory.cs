using Factory;
using UnityEngine;

namespace EnemyManagement
{
    public class EnemySpawnFactory<T> : RandomSpawnFactory<T> where T : Enemy
    {
        private const string DefaultEnemyName = "Enemy";

        public override GameObject Spawn(T enemy)
        {
            string enemyName = enemy.EnemySettingsHolder.EnemyName != string.Empty
                ? enemy.EnemySettingsHolder.EnemyName
                : DefaultEnemyName;

            GameObject enemyObject = enemy.gameObject;

            enemyObject = Object.Instantiate(enemyObject, GetRandomPositionOnPlane(Vector3.zero, 5f), Quaternion.identity);
            enemyObject.name = enemyName;

            return enemyObject;
        }
    }
}