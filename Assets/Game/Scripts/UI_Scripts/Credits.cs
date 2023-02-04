using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manor.Managers;


namespace Manor.UI.Objects
{
    public class Credits : MonoBehaviour
    {
        
        public void OpenCredits()
        {
            UIManager._instance._onCreditsOpened?.Invoke();
        }
    }  
}

