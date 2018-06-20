using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventoryItemValue : MonoBehaviour
    {
        [SerializeField]
        private Item m_ItemData;

        private Text m_Text;
        
        void Start()
        {
            m_Text = GetComponent<Text>();

            m_ItemData = GetComponentInParent<InventoryItemPanel>().itemData;

            m_Text.text = m_ItemData.Value.ToString();
        }
        
    } 
}
