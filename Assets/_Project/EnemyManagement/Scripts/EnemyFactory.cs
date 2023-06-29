using UnityEngine;

namespace EnemyManagement
{
    public class EnemyFactory
    {
        private const string DefaultEnemyName = "Enemy";

        public GameObject SpawnEnemy(Enemy enemy)
        {
            string enemyName = enemy.EnemySettingsHolder.EnemyName != string.Empty
                ? enemy.EnemySettingsHolder.EnemyName
                : DefaultEnemyName;

            GameObject enemyObject = enemy.gameObject;

            enemyObject = Object.Instantiate(enemyObject, enemyObject.transform.position, Quaternion.identity);
            enemyObject.name = enemyName;

            return enemyObject;
        }
    }
}