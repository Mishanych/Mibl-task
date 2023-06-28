using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LoadingScreenScene
{
    public class LoadingScreen : ILoadingScreenService
    {
        private const float FakeLoadDuration = 3f;

        public UnityEvent LoadingProcessFinished { get; } = new UnityEvent();

        public IEnumerator ShowFakeLoadingProcess(TMP_Text progressPercentageText, Slider progressBar)
        {
            float elapsedTime = 0f;

            while (elapsedTime < FakeLoadDuration)
            {
                float progress = elapsedTime / FakeLoadDuration;
                int progressPercentage = Mathf.RoundToInt(progress * 100);

                // Update the progress slider and text
                progressBar.value = progress;
                progressPercentageText.text = progressPercentage + "%";

                yield return null;

                elapsedTime += Time.deltaTime;
            }

            // Finish the loading process
            progressBar.value = 1f;
            progressPercentageText.text = "100%";

            // Wait for a short delay to show the completed progress
            yield return new WaitForSeconds(0.5f);

            // Hide the progress slider and text
            progressBar.gameObject.SetActive(false);
            progressPercentageText.gameObject.SetActive(false);

            LoadingProcessFinished?.Invoke();
            ResetLoadingProgress(progressPercentageText, progressBar);
        }

        private void ResetLoadingProgress(TMP_Text progressPercentageText, Slider progressBar)
        {
            progressPercentageText.text = "0%";
            progressBar.value = 0f;
        }
    }
}