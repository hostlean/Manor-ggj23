using Core;
using UnityEngine;

namespace Manor
{
    public class Sculpt : MonoBehaviour
    {
        [SerializeField] private GameEvent eventToFire;

        public void Close()
        {
            eventToFire.Fire();
        }
        
        
        
    }
}