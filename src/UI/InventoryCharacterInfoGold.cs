using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventoryCharacterInfoGold : MonoBehaviour
    {
        private Character m_CharData;
        private Text m_Text;

        void Start()
        {
            m_CharData = GetComponentInParent<InventoryUI>().characterData;
            m_Text = GetComponent<Text>();

            m_Text.text = m_CharData.Gold.ToString();
        }
        
    } 
}
