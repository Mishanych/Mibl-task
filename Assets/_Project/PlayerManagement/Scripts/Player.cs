using System;
using UnityEngine;

namespace PlayerManagement
{
    public class Player : MonoBehaviour
    {
        private const string HorizontalInputKeyWord = "Horizontal";
        private const string VerticalInputKeyWord = "Vertical";
        private const string EnemyTag = "Enemy";
        private const string BombTag = "Bomb";

        [SerializeField] private PlayerSettingsHolder _playerSettingsHolder;

        public bool IsAlive = true;

        private float _horizontalInput;
        private float _verticalInput;

        public event Action PlayerDied;

        private void Update()
        {
            GetInput();
            Move();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(EnemyTag) || other.gameObject.CompareTag(BombTag))
            {
                PlayerDied?.Invoke();
                IsAlive = false;
            }
        }

        private void GetInput()
        {
            _horizontalInput = Input.GetAxis(HorizontalInputKeyWord);
            _verticalInput = Input.GetAxis(VerticalInputKeyWord);
        }

        private void Move()
        {
            Vector3 direction = new Vector3(_horizontalInput, 0f, _verticalInput);
            transform.Translate(direction * _playerSettingsHolder.WalkSettings.Speed * Time.deltaTime);
        }
    }
}