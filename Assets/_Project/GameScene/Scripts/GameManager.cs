using PlayerManagement;
using UnityEngine;

namespace GameScene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private StopwatchManager _stopwatchManager;

        private void Start()
        {
            _stopwatchManager.StartStopwatch();
        }

        private void OnEnable()
        {
            _player.PlayerDied += EndGame;
        }

        private void OnDisable()
        {
            _player.PlayerDied -= EndGame;
        }

        private void EndGame()
        {
            _stopwatchManager.StopStopwatch();
            //show popup
           // _stopwatchManager.ElapsedTime   
        }
    }
}