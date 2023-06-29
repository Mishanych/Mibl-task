using UnityEngine;

namespace PlayerManagement
{
    [CreateAssetMenu(fileName = "WalkSettings", menuName = "ScriptableObjects/MoveSettings/WalkSettings")]
    public class WalkSettings : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}