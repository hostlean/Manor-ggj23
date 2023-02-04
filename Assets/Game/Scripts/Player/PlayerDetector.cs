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

            MemoryObject currentObj = null;
            foreach (var kvp in _memoryObjectDict)
            {
                var key = kvp.Key;
                var value = kvp.Value;


                currentObj = value;
            }
            
            currentObj?.DisplayName();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            var isMemoryObj = other.GetComponent<MemoryObject>();

            if (isMemoryObj)
            {
                AddMemoryObject(isMemoryObj);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var isMemoryObj = other.GetComponent<MemoryObject>();

            if (isMemoryObj)
            {
                RemoveMemoryObject(isMemoryObj);
            }
        }

        private void AddMemoryObject(MemoryObject obj)
        {
            var id = obj.gameObject.GetInstanceID();
            if (!_memoryObjectDict.ContainsKey(id))
            {
                _memoryObjectDict.Add(id, obj);
            }
        }

        private void RemoveMemoryObject(MemoryObject obj)
        {
            var id = obj.gameObject.GetInstanceID();
            if (_memoryObjectDict.ContainsKey(id))
            {
                _memoryObjectDict.Remove(id);
            }
        }
    }
}