using Core.ServiceLocator;
using PlayerManagement;
using UnityEngine;

namespace EnemyManagement
{
    public class SimpleEnemy : Enemy
    {
        private const float StoppingDistance = 0.1f;

        #region Services

        private IPlayerService _playerInstance;
        private IPlayerService _player
            => _playerInstance ??= Service.Instance.Get<IPlayerService>();

        #endregion

        private void Update()
        {
            ChaiseTarget(_player.Transform);
        }

        protected override void ChaiseTarget(Transform target)
        {
            if (target != null && _player.IsAlive)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToTarget > StoppingDistance)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);

                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,
                        _enemySettingsHolder.WalkSettings.RotationSpeed * Time.deltaTime);

                    transform.Translate(Vector3.forward * _enemySettingsHolder.WalkSettings.Speed * Time.deltaTime);
                }
            }
        }
    }
}