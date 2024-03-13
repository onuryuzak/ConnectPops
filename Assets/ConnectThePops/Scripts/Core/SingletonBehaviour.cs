namespace Scripts.Core
{
    using UnityEngine;

    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        protected static T instance = null;

        public static T Instance => instance;

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogError(string.Format("Multiple instances of {0} are not allowed", typeof(T)));

                Destroy(this);

                return;
            }

            instance = (T)this;
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}