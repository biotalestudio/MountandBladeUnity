using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class LocationText : MonoBehaviour
    {

        private LocationUI m_locationUI;
        private Text m_text;

        // Use this for initialization
        private void OnEnable()
        {
            m_locationUI = GetComponentInParent<LocationUI>();
            m_text = GetComponent<Text>();

            string str = m_locationUI.WhatToWrite();
            Color color = m_locationUI.GetColor();

            m_text.fontSize = 12;
            m_text.color = color;
            m_text.text = str;
        }
    }

}