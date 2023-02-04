using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manor
{
    public class PlayerDetector : MonoBehaviour
    {

        private Transform _transform;
        private void Awake()
        {
            _transform = transform;
        }

        private Dictionary<int, MemoryObject> _memoryObjectDict = new Dictionary<int, MemoryObject>();


        private void Update()
        {
            if(_memoryObjectDict.Count <= 0) 
                return;
            
            
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {
            
        }

        private void AddMemoryObject(MemoryObject obj)
        {
            
        }

        private void RemoveMemoryObject(MemoryObject obj)
        {
            
        }
    }
}