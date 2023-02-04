using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace Manor
{
    [CreateAssetMenu(fileName = "ItemInfo", menuName = "Item/ItemInfo", order = 0)]
    public class ItemInfo : ScriptableObject
    {
        public string itemName;
        
        [TextArea(1,4)]
        public string itemDescription;

        [TextArea(4,8)]
        public string itemStory;
    }    
}


