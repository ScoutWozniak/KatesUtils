

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
    
    static IEnumerable<Type> GetAllAutoloads(Assembly assembly) {
        foreach(Type type in assembly.GetTypes()) {
            if (type.GetCustomAttributes(typeof(AutoloadAttribute), true).Length > 0) {
                yield return type;
            }
        }
    }
}
