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
        
        public bool HasItem { get; set; }
        
        public Item CurrentItem { get; private set; }
        
        
        private void Awake()
        {
            HasItem = false;
            _transform = transform;
        }

        private readonly Dictionary<int, Item> _memoryObjectDict = new();


        private void Update()
        {
            if(isHolding) return;
            if(_memoryObjectDict.Count <= 0)
            {
                HasItem = false;
                return;
            }

            CurrentItem = null;
            foreach (var kvp in _memoryObjectDict)
            {
                var key = kvp.Key;
                var value = kvp.Value;


                if (CurrentItem != null)
                {
                    if (Vector3.Distance(value.transform.position, _transform.position) <
                        Vector3.Distance(CurrentItem.transform.position, _transform.position))
                    {
                        CurrentItem = value;
                        CurrentItem.HideName();
                    }
                }
                else
                {
                    CurrentItem = value;
                    CurrentItem.HideName();
                }
            }

            HasItem = true;
            CurrentItem?.ShowName(_transform);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            var isMemoryObj = other.GetComponentInParent<Item>();

            if (isMemoryObj)
            {
                Debug.Log("ITEM");
                AddMemoryObject(isMemoryObj);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var isMemoryObj = other.GetComponentInParent<Item>();

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
                _memoryObjectDict[id].HideName();
                _memoryObjectDict.Remove(id);
            }
        }

        public void SetHoldingStatus(bool status)
        {
            isHolding = status;
            OnHoldingStatusChanged?.Invoke(isHolding);
            foreach (var kvp in _memoryObjectDict)
            {
                var item = kvp.Value;
                item.HideName();
            }
        }

        public void ThrowItem()
        {
            if (HasItem)
            {
                CurrentItem.transform.SetParent(null);
                CurrentItem.GetThrown(_transform.forward, 20);
            }
        }
    }
}