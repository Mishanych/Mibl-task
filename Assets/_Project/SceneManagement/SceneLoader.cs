using System.IO;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : ISceneLoaderService
    {
        private const int IndexOfFirstScene = 0;
        private const string LoadingScreenScene = "LoadingScreen";

        private int _activeSceneIndex;

        public void EnableLoadingScreen()
        {
            SceneManager.LoadScene(LoadingScreenScene);
        }

        public void EnableSceneAfterLoading()
        {
            if (_activeSceneIndex == IndexOfFirstScene)
            {
                SwitchSceneForward();
            }

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