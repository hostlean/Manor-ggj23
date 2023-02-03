using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Manor
{
    public class Knife : MonoBehaviour
    {
        [SerializeField] private GameEventListener eventListener;
        
        public void Cut()
        {
            Debug.Log("Cut!!!!");
        }
        
        
    }
}

