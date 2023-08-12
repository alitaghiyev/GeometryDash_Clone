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
            EventManager.i.RestartEvent?.Invoke(this);
        }


        //bu metodlar yardimi ile eventin tetikledigi scriptlerde gerekli degerlere erisim sagliyoruz
        public GameObject GetPlayer() => Player;//ileride birden fazla farkli event tetikleye biliriz bu durumda her scriptde player tanimlak zorunda kalmayız
        public float GetResetTime() => _restartDelay;
        public PlayerMode GetResetMode() => PlayerMode.Cube;


        
        public void TimeScaleIsZero() => Time.timeScale = 0;
        public void TimeScaleIsOne() => Time.timeScale = 1;
    }
}
