using Unity.VisualScripting;
using UnityEngine;

namespace PawnSystem
{
    public class PawnSystem : MonoBehaviour
    {
        private Pawn _currentPawn;
        
        public static PawnSystem Instance { get; private set; }

        void Awake()
        {
            Instance = this;
        }
        
        public void SpawnPawn<T>(out T pawn, Vector3 position = default) where T : Pawn
        {
            pawn = null;
            var monoType = typeof(T);
            if (!monoType.HasAttribute(typeof(PawnAttribute)))
                return;
                
                
            var attrib = monoType.GetAttribute<PawnAttribute>();
            var path = attrib.prefabPath;
            var prefab = Resources.Load(path) as GameObject;
            if (!prefab)
                return;
            
            var spawned = Instantiate(prefab);
            if (spawned && spawned.TryGetComponent<T>(out var p))
            {
                pawn = p;
                pawn.transform.position = position;
                if (_currentPawn)
                    Destroy(_currentPawn.gameObject);
                _currentPawn = pawn;
                
            }
        }
        
    }
}