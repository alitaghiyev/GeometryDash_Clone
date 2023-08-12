using UnityEngine;
using UnityEngine.Events;
using System.Collections;
namespace GeometryDash
{
    public static class ExtensionMethods
    {
        #region Wait Extension
        /// <summary>
        /// Bu extension her scripte coroutine yazmaya gerek kalmadan istedigimiz kadar bekletip sonra bir olayi tetiklememizi saglar
        /// Kullanim sekli -------  this.Wait(BeklemeSuresi , () => { yapilacak isle; });
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

    }
}