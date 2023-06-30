using UnityEngine;
using TMPro;
using Core.ServiceLocator;
using SceneManagement;
using UnityEngine.UI;

namespace LoadingScreenScene
{
    public sealed class LoadingScreenProvider : MonoBehaviour
    {
        [SerializeField] private TMP_Text _progressPercentageText;
        [SerializeField] private Slider _progressBar;

        #region Services

        private ILoadingScreenService _loadingScreenInstance;
        private ILoadingScreenService _loadingScreen
            => _loadingScreenInstance ??= Service.Instance.Get<ILoadingScreenService>();

        private ISceneLoaderService _sceneLoaderInstance;
        private ISceneLoaderService _sceneLoader
            => _sceneLoaderInstance ??= Service.Instance.Get<ISceneLoaderService>();

        #endregion

        private void Awake()
        {
            StartCoroutine(_loadingScreen.ShowFakeLoadingProcess(_progressPercentageText, _progressBar));
        }

        private void OnEnable()
        {
            _loadingScreen.LoadingProcessFinished.AddListener(LoadingProcessFinished);
        }

        private void OnDisable()
        {
            _loadingScreen.LoadingProcessFinished.RemoveListener(LoadingProcessFinished);
        }

        private void LoadingProcessFinished()
        {
            _sceneLoader.EnableSceneAfterLoading();
        }
    }
}