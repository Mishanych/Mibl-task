using UnityEngine;

namespace GameScene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StopwatchManager _stopwatchManager;

        private void Start()
        {
            _stopwatchManager.StartStopwatch();
        }
    }
}