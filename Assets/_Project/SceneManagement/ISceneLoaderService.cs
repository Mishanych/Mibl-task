using Core.ServiceLocator;

namespace SceneManagement
{
    public interface ISceneLoaderService : IService
    {
        void EnableLoadingScreen();
        void EnableSceneAfterLoading();
        void SwitchSceneForward();
        void SwitchSceneBack();
    }
}