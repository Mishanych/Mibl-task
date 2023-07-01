using UnityEngine;
using UnityEngine.Events;

namespace PlayerManagement
{
    public class Player : IPlayerService
    {
        private const string HorizontalInputKeyWord = "Horizontal";
        private const string VerticalInputKeyWord = "Vertical";
        private const int SpeedMultiplier = 20;

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
            #if UNITY_EDITOR
            _horizontalInput = Input.GetAxis(HorizontalInputKeyWord);
            _verticalInput = Input.GetAxis(VerticalInputKeyWord);
            #endif

        }

        public void Move(Transform player, PlayerSettingsHolder playerSettingsHolder)
        {
#if UNITY_EDITOR
            Vector3 direction = new Vector3(_horizontalInput, 0f, _verticalInput);
            player.Translate(direction * playerSettingsHolder.WalkSettings.Speed * SpeedMultiplier * Time.deltaTime);
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 direction2 = new Vector3(
                        touch.deltaPosition.x,
                        0f,
                        touch.deltaPosition.y);

                    player.Translate(direction2 * playerSettingsHolder.WalkSettings.Speed * Time.deltaTime);
                }
            }
#endif
        }

        public void Kill()
        {
            IsAlive = false;
            PlayerDied?.Invoke();
        }
    }
}