using UnityEngine;
using UnityEngine.Events;
using System.Collections;
namespace GeometryDash
{
    public static class ExtensionMethods
    {
        #region Wait Extension
        /// <summary>
        /// How to use --> "this.Wait(delay , () => { do it; })";
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="delay"></param>
        /// <param name="action"></param>
        public static void Wait(this MonoBehaviour mono, float delay, UnityAction action)
        {
            mono.StartCoroutine(ExecuteAction(delay, action));
        }
        private static IEnumerator ExecuteAction(float delay, UnityAction action)
        {
            yield return new WaitForSecondsRealtime(delay);
            action?.Invoke();
            yield break;
        }
        #endregion

        #region Collider Extension
        public static void SetColliderAsTrigger<T>(this MonoBehaviour monoBehaviour) where T : Collider2D
        {
            T collider = monoBehaviour.GetComponent<T>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }
        }
        #endregion
      
    }
}