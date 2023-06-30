using UnityEngine;

namespace PlayerManagement
{
    [CreateAssetMenu(fileName = "WalkSettings", menuName = "ScriptableObjects/MoveSettings/WalkSettings")]
    public class WalkSettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;
    }
}