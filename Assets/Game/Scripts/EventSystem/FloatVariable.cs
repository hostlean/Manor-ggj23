using System;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Variable/Float", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;
        
        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                FireOnValueChanged();
            }
        }
        
        
        public event Action OnValueChanged;
        private void FireOnValueChanged()
        {
            OnValueChanged?.Invoke();
        }

    }
}