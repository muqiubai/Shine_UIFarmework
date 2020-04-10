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
    /// Private constructor, avoid external instantiation
    /// </summary>
    private SingtonManager() { }

    /// <summary>
    /// Thread lock
    /// </summary>
    private static readonly object _lock = new object();
}
