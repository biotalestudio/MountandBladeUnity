using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class AttributeButtonLogic : MonoBehaviour
    {

        public Character charData;
        public Attributes whichAttribute;

        private Button m_button;
        private Image m_image;



        // Use this for initialization
        void Start()
        {
            m_button = GetComponent<Button>();
            m_image = GetComponent<Image>();
        }

        public void ApplyStats()
        {
            switch (whichAttribute)
            {
                case Attributes.Strength:
                    charData.Strength++;
                    charData.AttributePoints--;
                    break;
                case Attributes.Agility:
                    charData.Agility++;
                    charData.AttributePoints--;
                    break;
                case Attributes.Intelligence:
                    charData.Intelligence++;
                    charData.AttributePoints--;
                    break;
                case Attributes.Charisma:
                    charData.Charisma++;
                    charData.AttributePoints--;
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (charData.AttributePoints > 0)
            {
                m_button.enabled = true;
                m_image.enabled = true;
            }
            else
            {
                m_button.enabled = false;
                m_image.enabled = false;
            }
        }
    }

}