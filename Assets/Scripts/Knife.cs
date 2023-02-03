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
        [SerializeField] private FloatVariable healthVariable;


        private void Awake()
        {
            healthVariable.OnValueChanged += CheckHealthAndKill;
        }

        private void CheckHealthAndKill()
        {
            if (healthVariable.Value <= 0)
            {
                Debug.Log("DIEEE!!!");
            }
        }

        public void Cut()
        {
            Debug.Log("Cut!!!!");
        }
        
        
    }
}

