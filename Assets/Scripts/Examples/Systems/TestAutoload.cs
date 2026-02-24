using Autoloads;
using UnityEngine;

namespace Examples.Systems
{
    [Autoload("Test")]
    public class TestAutoload : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Auto loaded!");
        }
        
        
    }
}