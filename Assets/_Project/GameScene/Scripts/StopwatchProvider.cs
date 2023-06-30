using Core.ServiceLocator;
using TMPro;
using UnityEngine;

namespace GameScene
{
    public class StopwatchProvider : MonoBehaviour
    {
        [SerializeField] private TMP_Text _stopwatchText;

        #region Services

        private IStopwatchService _stopwatchInstance;
        private IStopwatchService _stopwatch
            => _stopwatchInstance ??= Service.Instance.Get<IStopwatchService>();

        #endregion

        private void Awake()
        {
            _stopwatch.Reset(_stopwatchText);
            _stopwatch.Start();
        }

        private void Update()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.UpdateTime(Time.deltaTime);
                _stopwatch.UpdateTimeText(_stopwatchText);
            }
        }
    }
}