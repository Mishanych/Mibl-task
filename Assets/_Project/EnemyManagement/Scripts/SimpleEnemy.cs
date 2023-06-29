using System;
using PlayerManagement;
using UnityEngine;

namespace EnemyManagement
{
    public class SimpleEnemy : Enemy
    {
        private void Update()
        {
            ChaiseTarget(FindObjectOfType<Player>().transform);
        }

        protected override void ChaiseTarget(Transform target)
        {
            if (target != null)
            {
                Vector3 direction = (target.position - transform.position).normalized;

                transform.Translate(direction * _enemySettingsHolder.WalkSettings.Speed * Time.deltaTime);
            }
        }
    }
}