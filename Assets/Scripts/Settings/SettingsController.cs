using UnityEngine;

namespace GeometryDash
{
    public class SettingsController : MonoBehaviour
    {
        [Header("Music")]
        public static bool isMusic = true;
        public GameObject musicOnPanel, musicOffPanel;
        public AudioSource musicSource;

        //[Header("Sound")]
        //public static bool isSound = true;
        //public GameObject soundOnPanel, soundOffPanel;


        private void Start()
        {
            //SetSound(PlayerPrefs.GetInt("isSound") == 0 ? true : false);
            SetMusic(PlayerPrefs.GetInt("isMusic") == 0 ? true : false);
        }

        //public void SetSound(bool value)
        //{
        //    isSound = value;
        //    PlayerPrefs.SetInt("isSound", value == true ? 0 : 1);
        //    soundOnPanel.SetActive(value);
        //    soundOffPanel.SetActive(!value);
        //}

        public void SetMusic(bool value)
        {
            isMusic = value;
            musicSource.enabled = value;
            PlayerPrefs.SetInt("isMusic", value == true ? 0 : 1);
            musicOnPanel.SetActive(value);
            musicOffPanel.SetActive(!value);
        }
    }
}
