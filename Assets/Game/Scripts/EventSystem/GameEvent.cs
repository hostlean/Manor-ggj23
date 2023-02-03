using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Event/GameEvent", order = 0)]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private List<GameEventListener> listeners;

        public void AddListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Fire()
        {
            foreach (var listener in listeners)
            {
                listener.response.Invoke();
            }
        }
    }
}


