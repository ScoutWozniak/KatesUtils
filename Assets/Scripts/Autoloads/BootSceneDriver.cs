

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autoloads;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class EditorInit
{ 
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnPlayModeStateChanged() {

        var go = new GameObject
        {
            name = "AutoloadManager"
        };
        Object.DontDestroyOnLoad(go);
        go.AddComponent<AutoloadManager>();
    }
}

public class AutoloadManager : MonoBehaviour
{
    private static AutoloadManager _instance;

    void Awake()
    {
        _instance = this;
    }
    
    void Start()
    {
        Debug.Log("Finding all autoloads");
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var autoload in GetAllAutoloads(assembly))
            {
                var go =  new GameObject();
                go.name = autoload.GetCustomAttribute<AutoloadAttribute>().Name;
                go.AddComponent(autoload);
                
                go.transform.SetParent(gameObject.transform);

            }
        }
    }

    public static bool TryGetAutoload<T>(out  T autoload) where T : MonoBehaviour
    {
        if (!_instance)
        {
            autoload = null;
            return false;
        }
        
        autoload = _instance.GetComponentInChildren<T>();
        return autoload;
    }
    
    static IEnumerable<Type> GetAllAutoloads(Assembly assembly) {
        foreach(Type type in assembly.GetTypes()) {
            if (type.GetCustomAttributes(typeof(AutoloadAttribute), true).Length > 0) {
                yield return type;
            }
        }
    }
}
