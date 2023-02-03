using System;
using UnityEngine;

namespace Core
{
    public class TestVariable : MonoBehaviour
    {
        public FloatReference testVal;
        private void Awake()
        {
            testVal.Value = 40;
        }

        public void TestEventInvoke()
        {
            Debug.Log("INVOKED!!!");
        }
    }
}