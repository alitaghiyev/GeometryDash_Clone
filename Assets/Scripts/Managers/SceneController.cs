using UnityEngine;
using UnityEngine.SceneManagement;
namespace GeometryDash
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private float TransitionDelay = .3f;

        [HideInInspector] public SceneName sceneName;
        public enum SceneName
        {
            MainMenu = 0,
            Level1 = 1
        }
        public void ChangeSceneWithIndex(int sceneIndex)
        {
            //TODO: trasition effect 
            this.Wait(TransitionDelay, () => { SceneManager.LoadScene(sceneIndex); });
        }
        public void ChangeSceneWithName(SceneName sceneName)
        {
            ChangeSceneWithIndex((int)sceneName);
        }


    }
}