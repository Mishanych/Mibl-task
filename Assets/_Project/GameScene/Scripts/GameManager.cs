using Core.ServiceLocator;
using PlayerManagement;
using Popups.EndScreen;
using SceneManagement;
using UnityEngine;

namespace GameScene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private EndScreen _endScreen;

        #region Services

        private ISceneLoaderService _sceneLoaderInstance;
        private ISceneLoaderService _sceneLoader
            => _sceneLoaderInstance ??= Service.Instance.Get<ISceneLoaderService>();

        private IStopwatchService _stopwatchInstance;
        private IStopwatchService _stopwatch
            => _stopwatchInstance ??= Service.Instance.Get<IStopwatchService>();

        private IPlayerService _playerInstance;
        private IPlayerService _player
            => _playerInstance ??= Service.Instance.Get<IPlayerService>();

        #endregion

        private void OnEnable()
        {
            _player.PlayerDied.AddListener(EndGame);

            _endScreen.RestartButtonClicked += RestartGame;
            _endScreen.MainMenuClicked += GoToMainMenu;
        }

        private void OnDisable()
        {
            _player.PlayerDied.RemoveListener(EndGame);

            _endScreen.RestartButtonClicked -= RestartGame;
            _endScreen.MainMenuClicked -= GoToMainMenu;
        }

        private void EndGame()
        {
            _stopwatch.Stop();
            _endScreen.gameObject.SetActive(true);
        }

        private void RestartGame()
        {
            _endScreen.gameObject.SetActive(false);
            _sceneLoader.EnableLoadingScreen();
        }

        private void GoToMainMenu()
        {
            _endScreen.gameObject.SetActive(false);
            _sceneLoader.SwitchSceneBack();
            _sceneLoader.EnableLoadingScreen();
        }
    }
}