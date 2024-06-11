using UnityEngine;
namespace GeometryDash
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float _restartDelay = 1f;
        [SerializeField] private GameObject Player;

        private void Start()
        {
            TimeScaleIsOne();
        }

        public void ResetGame()
        {
            EventManager.Instance.RestartEvent?.Invoke(this);
        }

        public GameObject GetPlayer() => Player;
        public float GetResetTime() => _restartDelay;

        
        
        public void TimeScaleIsZero() => Time.timeScale = 0;
        public void TimeScaleIsOne() => Time.timeScale = 1;
    }
}
