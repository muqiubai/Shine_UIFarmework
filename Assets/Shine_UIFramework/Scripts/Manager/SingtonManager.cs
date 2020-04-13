using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic singleton Manager
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingtonManager<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Thread lock
    /// </summary>
    private static readonly object _lock = new object();

    private static T _instance = null;

    /// <summary>
    /// 
    /// </summary>
    private static bool isAlive;

    private void Awake()
    {
        isAlive = false;
    }

    private void OnApplicationQuit()
    {
        isAlive = true;
    }

    private void OnDestroy()
    {
        isAlive = true;
    }

    public static T Instance
    {
        get
        {
            if (isAlive)
            {
                return null;
            }

            lock(_lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length >= 1)
                    {
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();

                        singleton.name = "(Singleton)" + typeof(T);
                        singleton.hideFlags = HideFlags.None;

                        DontDestroyOnLoad(singleton);
                    }
                    else
                    {
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }
            }

            _instance.hideFlags = HideFlags.None;

            return _instance;
        }
    }
}
