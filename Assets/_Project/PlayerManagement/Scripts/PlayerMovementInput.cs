using UnityEngine;

namespace PlayerManagement
{
    public class PlayerMovementInput : MonoBehaviour
    {
        private const string HorizontalInputKeyWord = "Horizontal";
        private const string VerticalInputKeyWord = "Vertical";

        [SerializeField] private PlayerSettingsHolder _playerSettingsHolder;

        private float _horizontalInput;
        private float _verticalInput;

        private void Update()
        {
            GetInput();
            Move();
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