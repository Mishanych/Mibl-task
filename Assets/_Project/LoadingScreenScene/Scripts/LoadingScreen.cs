using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LoadingScreenScene
{
    public class LoadingScreen : ILoadingScreenService
    {
        private const float FakeLoadDuration = 2f;
        private const float DelayToShowCompletedProgress = 0.5f;
        private const float MinProgressBarValue = 0f;
        private const float MaxProgressBarValue = 1f;
        private const float MaxPercentageValue = 100f;

        private const string MinProgressPercentageText = "0%";
        private const string MaxProgressPercentageText = "100%";
        private const string ProgressPercentageSymbol = "%";

        public UnityEvent LoadingProcessFinished { get; } = new UnityEvent();

        public IEnumerator ShowFakeLoadingProcess(TMP_Text progressPercentageText, Slider progressBar)
        {
            float elapsedTime = 0f;

            while (elapsedTime < FakeLoadDuration)
            {
                float progress = elapsedTime / FakeLoadDuration;
                int progressPercentage = Mathf.RoundToInt(progress * MaxPercentageValue);

                progressBar.value = progress;
                progressPercentageText.text = progressPercentage + ProgressPercentageSymbol;

                yield return null;

                elapsedTime += Time.deltaTime;
            }

            progressBar.value = MaxProgressBarValue;
            progressPercentageText.text = MaxProgressPercentageText;

            yield return new WaitForSeconds(DelayToShowCompletedProgress);

            progressBar.gameObject.SetActive(false);
            progressPercentageText.gameObject.SetActive(false);

            LoadingProcessFinished?.Invoke();
            ResetLoadingProgress(progressPercentageText, progressBar);
        }

        private void ResetLoadingProgress(TMP_Text progressPercentageText, Slider progressBar)
        {
            progressPercentageText.text = MinProgressPercentageText;
            progressBar.value = MinProgressBarValue;
        }
    }
}