using Core.ServiceLocator;
using UnityEngine;

namespace Core.Persistent
{
    public static class PersistentServiceBinder
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void RegisterServices()
        {
            Service serviceInstance = Service.Instance;
        }
    }
}