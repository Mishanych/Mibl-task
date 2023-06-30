using UnityEngine;

namespace EnemyManagement
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected EnemySettingsHolder _enemySettingsHolder;

        public EnemySettingsHolder EnemySettingsHolder => _enemySettingsHolder;

        protected abstract void ChaiseTarget(Transform target);
    }
}