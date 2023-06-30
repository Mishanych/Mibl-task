using Factory;
using UnityEngine;

namespace EnemyManagement
{
    public class EnemySpawnFactory : RandomSpawnFactory<Enemy>
    {
        private const string DefaultEnemyName = "Enemy";
        private const float YAxisOffset = 0.5f;

        public override GameObject Spawn(Enemy enemy, Vector3 planeCenter)
        {
            string enemyName = enemy.EnemySettingsHolder.EnemyName != string.Empty
                ? enemy.EnemySettingsHolder.EnemyName
                : DefaultEnemyName;

            planeCenter = new Vector3(planeCenter.x, planeCenter.y + YAxisOffset, planeCenter.z);

            GameObject enemyObject = enemy.gameObject;

            enemyObject = Object.Instantiate(enemyObject,
                GetRandomPositionOnPlane(planeCenter, enemy.EnemySettingsHolder.SpawnSettings.SpawnedRadius),
                Quaternion.identity);

            enemyObject.name = enemyName;

            return enemyObject;
        }
    }
}