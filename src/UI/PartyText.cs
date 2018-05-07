using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class PartyText : MonoBehaviour
    {

        PartyUI m_partyUI;
        Text m_text;

        // Use this for initialization
        void OnEnable()
        {
            m_partyUI = GetComponentInParent<PartyUI>();
            m_text = GetComponent<Text>();

            string stringToWrite = m_partyUI.WhatToWrite();
            int stringLength = stringToWrite.Length;
            m_text.fontSize = 12;

            if (stringLength > 30)
            {
                m_text.fontSize = 10;
            }

            m_text.text = stringToWrite;
            m_text.color = m_partyUI.GetCurrentColor();
        }


        // Update is called once per frame
        void Update()
        {

        }
    }

}