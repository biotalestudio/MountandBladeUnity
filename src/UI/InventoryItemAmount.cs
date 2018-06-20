using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventoryItemAmount : MonoBehaviour
    {
        public Item itemData;

        private Text m_Text;
        
        void Start()
        {
            m_Text = GetComponent<Text>();
        }
        
    } 
}
