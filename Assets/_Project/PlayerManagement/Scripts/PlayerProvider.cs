using Core.ServiceLocator;
using UnityEngine;

namespace PlayerManagement
{
    public class PlayerProvider : MonoBehaviour
    {
        private const string EnemyTag = "Enemy";
        private const string BombTag = "Bomb";

        [SerializeField] private PlayerSettingsHolder _playerSettingsHolder;

        #region Services

        private IPlayerService _playerInstance;
        private IPlayerService _player
            => _playerInstance ??= Service.Instance.Get<IPlayerService>();

        #endregion

        private void Awake()
        {
            _player.SetPlayerTransform(transform);
            _player.MakePlayerAlive();
        }

        private void Update()
        {
            if (_player.IsAlive)
            {
                _player.GetInput();
                _player.Move(transform, _playerSettingsHolder);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(EnemyTag) || other.gameObject.CompareTag(BombTag))
            {
                _player.Kill();
            }
        }
    }
}