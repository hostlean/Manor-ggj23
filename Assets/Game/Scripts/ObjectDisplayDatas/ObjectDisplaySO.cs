using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Manor
{
    [CreateAssetMenu]
    public class ObjectDisplaySO : ScriptableObject
    {
        public string _objectName;

        [TextArea(1,4)]
        public string _objectDescription;
    }    
}


