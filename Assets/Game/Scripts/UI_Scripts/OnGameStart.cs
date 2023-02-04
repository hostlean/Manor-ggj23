using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manor;
using Core;

namespace Manor.GameStart
{
    public class OnGameStart : MonoBehaviour
    {
        [SerializeField] GameEvent startGameEvent;
        private void Start() 
        {
            startGameEvent.Fire();
        }
    } 
}

