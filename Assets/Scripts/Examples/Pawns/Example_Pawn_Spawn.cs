using UnityEngine;
using PawnSystem;
namespace Examples.Pawns
{
    public class Example_Pawn_Spawn : MonoBehaviour
    {
        void Start()
        {
            PawnSystem.PawnSystem.Instance.SpawnPawn<SpectatorPawn>(out var pawn, transform.position);
        }
    }
}