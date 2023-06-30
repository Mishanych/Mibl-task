using System;
using Core.ServiceLocator;
using GameScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popups.EndScreen
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private TMP_Text _finalTimeText;

        public event Action RestartButtonClicked;
        public event Action MainMenuClicked;

        #region Services

        private IStopwatchService _stopwatchInstance;
        private IStopwatchService _stopwatch
            => _stopwatchInstance ??= Service.Instance.Get<IStopwatchService>();

        #endregion

        private void Awake()
        {
            _finalTimeText.text = _stopwatch.ConvertElapsedTimeToText();
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        }

        private void RestartGame()
        {
            RestartButtonClicked?.Invoke();
        }

        private void GoToMainMenu()
        {
            MainMenuClicked?.Invoke();
        }
    }
}