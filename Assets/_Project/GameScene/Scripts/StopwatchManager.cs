using TMPro;
using UnityEngine;

namespace GameScene.Scripts
{
    public class StopwatchManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _stopwatchText;

        private bool _isRunning;
        private float _elapsedTime;

        public float ElapsedTime => _elapsedTime;

        private void Update()
        {
            if (_isRunning)
            {
                _elapsedTime += Time.deltaTime;
                UpdateTimeText();
            }
        }

        private void UpdateTimeText()
        {
            int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60f);

            _stopwatchText.text = $"{minutes:00}:{seconds:00}";
        }

        public void StartStopwatch()
        {
            _isRunning = true;
        }

        public void StopStopwatch()
        {
            _isRunning = false;
        }

        public void ResetStopwatch()
        {
            _elapsedTime = 0f;
            UpdateTimeText();
        }
    }
}