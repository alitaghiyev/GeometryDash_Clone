using UnityEngine;

namespace GeometryDash
{
    public class MusicManager : MonoBehaviour
    {
        public AudioSource musicSource;
        public AudioClip[] musicClips;

        private void Start()
        {
            musicSource.clip = musicClips[Random.Range(0, musicClips.Length)];          
            musicSource.Play();
        }
    }
}
