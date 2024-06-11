using System;
using UnityEngine.Events;
namespace GeometryDash
{
    public class EventManager : MonoSingleton<EventManager>
    {
        #region  GENERIC EVENT CLASSES
        [Serializable] public class GameEvent : UnityEvent { }
        [Serializable] public class GameEvent<T0> : UnityEvent<T0> { }
        [Serializable] public class GameEvent<T0, T1> : UnityEvent<T0, T1> { }
        #endregion

        /// <summary>
        /// gamenanagerde reset islevini tetiklemek icin
        /// </summary>
        public GameEvent DeadEvent;

        /// <summary>
        /// bitis çizgisine dokundugunda tetiklenir ui, sound, timescale vs icin kullanilir
        /// </summary>
        public GameEvent FinishEvent;


        public GameEvent<GameManager> RestartEvent;

    }

}