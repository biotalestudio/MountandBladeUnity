using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class AttributesTextLogic : MonoBehaviour
    {

        public Character playerData;
        public Attributes whichAttribute;

        private Text m_text;

        // Use this for initialization
        void Start()
        {
            m_text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (whichAttribute)
            {
                case Attributes.Strength:
                    m_text.text = "STR: " + playerData.Strength;
                    break;
                case Attributes.Agility:
                    m_text.text = "AGI: " + playerData.Agility;
                    break;
                case Attributes.Intelligence:
                    m_text.text = "INT: " + playerData.Intelligence;
                    break;
                case Attributes.Charisma:
                    m_text.text = "CHA: " + playerData.Charisma;
                    break;
            }
        }
    }

}