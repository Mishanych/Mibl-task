using System.IO;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : ISceneLoaderService
    {
        private const int IndexOfNonExistentScene = -1;
        private const string LoadingScreenScene = "LoadingScreen";

        private int _activeSceneIndex = 0;

        public void EnableLoadingScreen()
        {
            SceneManager.LoadScene(LoadingScreenScene);
        }

        public void EnableSceneAfterLoading()
        {
            string pathToScene = SceneUtility.GetScenePathByBuildIndex(_activeSceneIndex);
            string sceneName = Path.GetFileNameWithoutExtension(pathToScene);

            SceneManager.LoadScene(sceneName);
        }

        public void SwitchSceneForward()
        {
            _activeSceneIndex++;
        }

        public void SwitchSceneBack()
        {
            _activeSceneIndex--;
        }
    }
}