using Core.ServiceLocator;
using TMPro;

namespace GameScene
{
    public interface IStopwatchService : IService
    {
        bool IsRunning { get; }
        float ElapsedTime { get; }

        void UpdateTimeText(TMP_Text stopwatchText);
        void UpdateTime(float elapsedTime);
        void Start();
        void Stop();
        void Reset(TMP_Text stopwatchText);
        string ConvertElapsedTimeToText();
    }
}