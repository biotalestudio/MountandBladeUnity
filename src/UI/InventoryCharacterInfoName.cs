using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventoryCharacterInfoName : MonoBehaviour
    {
        private Character m_CharacterData;

        private Text m_Text;

        void Start()
        {
            m_CharacterData = GetComponentInParent<InventoryUI>().characterData;

            m_Text = GetComponent<Text>();

            m_Text.text = m_CharacterData.Name;
        }

    } 
}
