using UnityEngine;

namespace PlayerManagement
{
    [CreateAssetMenu(fileName = "MoveSettingHolder", menuName = "ScriptableObjects/Settings/PlayerSettingsHolder")]
    public class PlayerSettingsHolder : ScriptableObject
    {
        [SerializeField] private WalkSettings _walkSettings;

        public WalkSettings WalkSettings => _walkSettings;
    }
}