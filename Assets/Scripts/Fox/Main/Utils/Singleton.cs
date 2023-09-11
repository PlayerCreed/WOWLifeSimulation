using System;
using UnityEngine;

namespace Fox
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;

        public static T instance => getInstance();

        public static bool isInit => _instance != null;
        //二次检查锁定有问题
        static readonly object syslock = new object();

        private static T getInstance()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    else
                    {
                        return _instance;
                    }
                }
            }

            return _instance;
        }

        public static void Destroy()
        {
            if (_instance != null)
            {
                if (_instance is IDisposable)
                {
                    (_instance as IDisposable).Dispose();
                }
                _instance = null;
            }
        }
    }

    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, IDisposable
    {
        private static T _instance = null;

        static readonly object syslock = new object();

        public static T instance => getInstance();

        private static T getInstance()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                    if (_instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        _instance = go.AddComponent<T>();
                        GameObject parent = GameObject.Find("Boot");
                        if (parent != null)
                        {
                            go.transform.parent = parent.transform;
                        }
                    }
                }
            }

            return _instance;
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }

            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
                Init();
            }
        }

        protected virtual void Init() { }

        public void DestroySelf()
        {
            Dispose();
            MonoSingleton<T>._instance = null;
            UnityEngine.Object.Destroy(gameObject);
        }

        public virtual void Dispose() { }
    }

}
