using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent eventToListen;
        
        public UnityEvent response;

        private void OnEnable()
        {
            if(eventToListen != null)
                eventToListen.AddListener(this);
        }

        private void OnDisable()
        {
            if(eventToListen != null)
                eventToListen.RemoveListener(this);
        }
    }
}