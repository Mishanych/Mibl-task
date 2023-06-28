using Core.ServiceLocator;
using LoadingScreenScene;
using UnityEngine;

namespace Core.Persistent
{
    public static class PersistentServiceBinder
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void RegisterServices()
        {
            Service serviceInstance = Service.Instance;

            serviceInstance.Register<ILoadingScreenService>(new LoadingScreen());
        }
    }
}