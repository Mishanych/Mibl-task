using TMPro;
using UnityEngine;

namespace GameScene
{
    public class Stopwatch : IStopwatchService
    {
        private const float MinTimeValue = 0f;
        private const float AmountOfSecondsInOneMinute = 60f;

        public bool IsRunning { get; private set; }
        public float ElapsedTime { get; private set; }

        public void UpdateTimeText(TMP_Text stopwatchText)
        {
            stopwatchText.text = ConvertElapsedTimeToText();
        }

        public void UpdateTime(float elapsedTime)
        {
            ElapsedTime += elapsedTime;
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Reset(TMP_Text stopwatchText)
        {
            ElapsedTime = MinTimeValue;
            UpdateTimeText(stopwatchText);
        }

        public string ConvertElapsedTimeToText()
        {
            int minutes = Mathf.FloorToInt(ElapsedTime / AmountOfSecondsInOneMinute);
            int seconds = Mathf.FloorToInt(ElapsedTime % AmountOfSecondsInOneMinute);

            return $"{minutes:00}:{seconds:00}";
        }
    }
}