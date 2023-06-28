using Core.ServiceLocator;
using SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuScene.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        #region Services

        private ISceneLoaderService _sceneLoaderInstance;
        private ISceneLoaderService _sceneLoader
            => _sceneLoaderInstance ??= Service.Instance.Get<ISceneLoaderService>();

        #endregion

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            _sceneLoader.EnableLoadingScreen();
        }
    }
}