using Core.ServiceLocator;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerManagement
{
    public interface IPlayerService : IService
    {
        UnityEvent PlayerDied { get; }
        bool IsAlive { get; }
        Transform Transform { get; }

        void MakePlayerAlive();
        void SetPlayerTransform(Transform playerTransform);
        void GetInput();
        void Move(Transform player, PlayerSettingsHolder playerSettingsHolder);
        void Kill();
    }
}