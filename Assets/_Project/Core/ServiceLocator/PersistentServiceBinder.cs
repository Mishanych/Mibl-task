using Core.ServiceLocator;
using GameScene;
using LoadingScreenScene;
using PlayerManagement;
using SceneManagement;
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
            serviceInstance.Register<ISceneLoaderService>(new SceneLoader());
            serviceInstance.Register<IStopwatchService>(new Stopwatch());
            serviceInstance.Register<IPlayerService>(new Player());
        }
    }
}