using UnityEngine;
namespace GeometryDash
{
    public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoSingleton<T>
    {
        public static T instance;
        public static T Instance
        {
            get
            {
                instance ??= GameObject.FindObjectOfType<T>();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        protected void Awake()
        {
            Instance = (T)this;
        }
    }
}