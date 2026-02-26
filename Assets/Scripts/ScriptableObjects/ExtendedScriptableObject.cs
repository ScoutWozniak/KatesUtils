using System;
using UnityEngine;

namespace ScriptableObjects
{
    public class ExtendedScriptableObject : ScriptableObject
    {
        public ExtendedScriptableObject referenceScriptableObject;

        private void Awake()
        {
            Debug.Log($"Awaking {name}");
        }

        private void OnDestroy()
        {
            Debug.Log($"Destroying {name}");
        }
    }
}