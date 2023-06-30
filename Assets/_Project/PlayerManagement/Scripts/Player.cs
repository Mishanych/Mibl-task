using UnityEngine;
using UnityEngine.Events;

namespace PlayerManagement
{
    public class Player : IPlayerService
    {
        private const string HorizontalInputKeyWord = "Horizontal";
        private const string VerticalInputKeyWord = "Vertical";

        private float _horizontalInput;
        private float _verticalInput;

        public UnityEvent PlayerDied { get; } = new UnityEvent();
        public bool IsAlive { get; private set; }
        public Transform Transform { get; private set; }

        public void MakePlayerAlive()
        {
            IsAlive = true;
        }

        public void SetPlayerTransform(Transform playerTransform)
        {
            Transform = playerTransform;
        }

        public void GetInput()
        {
            _horizontalInput = Input.GetAxis(HorizontalInputKeyWord);
            _verticalInput = Input.GetAxis(VerticalInputKeyWord);
        }

        public void Move(Transform player, PlayerSettingsHolder playerSettingsHolder)
        {
            Vector3 direction = new Vector3(_horizontalInput, 0f, _verticalInput);
            player.Translate(direction * playerSettingsHolder.WalkSettings.Speed * Time.deltaTime);
        }

        public void Kill()
        {
            IsAlive = false;
            PlayerDied?.Invoke();
        }
    }
}