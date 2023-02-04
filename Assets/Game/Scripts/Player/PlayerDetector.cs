using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manor
{
    public class PlayerDetector : MonoBehaviour
    {

        private Transform _transform;
        private bool isHolding;
        public event Action<bool> OnHoldingStatusChanged;
        private void Awake()
        {
            _transform = transform;
        }

        private readonly Dictionary<int, Item> _memoryObjectDict = new();


        private void Update()
        {
            if(_memoryObjectDict.Count <= 0) 
                return;

            Item currentItem = null;
            foreach (var kvp in _memoryObjectDict)
            {
                var key = kvp.Key;
                var value = kvp.Value;


                if (currentItem != null)
                {
                    if (Vector3.Distance(value.transform.position, _transform.position) <
                        Vector3.Distance(currentItem.transform.position, _transform.position))
                    {
                        currentItem = value;
                    }
                }
                else
                {
                    currentItem = value;
                }
            }
            
            currentItem?.ShowName();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            var isMemoryObj = other.GetComponent<Item>();

            if (isMemoryObj)
            {
                AddMemoryObject(isMemoryObj);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var isMemoryObj = other.GetComponent<Item>();

            if (isMemoryObj)
            {
                RemoveMemoryObject(isMemoryObj);
            }
        }

        private void AddMemoryObject(Item item)
        {
            var id = item.gameObject.GetInstanceID();
            if (!_memoryObjectDict.ContainsKey(id))
            {
                _memoryObjectDict.Add(id, item);
            }
        }

        private void RemoveMemoryObject(Item item)
        {
            var id = item.gameObject.GetInstanceID();
            if (_memoryObjectDict.ContainsKey(id))
            {
                _memoryObjectDict.Remove(id);
            }
        }

        public void SetHoldingStatus(bool status)
        {
            isHolding = status;
            OnHoldingStatusChanged?.Invoke(isHolding);
        }
    }
}