using ScriptableObjects;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu]
    public class SoundResource : ExtendedScriptableObject
    {
        public AudioClip audioClip;
    }
}