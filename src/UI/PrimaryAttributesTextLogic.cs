using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class PrimaryAttributesTextLogic : MonoBehaviour
    {

        public PrimaryAttributes whichPrimaryAttribute;

        private Text m_text;
        private Character m_charData;

        // Use this for initialization
        void Start()
        {
            m_text = GetComponent<Text>();
            m_charData = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().charData;
        }

        // Update is called once per frame
        void Update()
        {
            switch (whichPrimaryAttribute)
            {
                case PrimaryAttributes.Health:
                    m_text.text = "Health: " + m_charData.Health;
                    break;
                case PrimaryAttributes.Level:
                    m_text.text = "Level: " + m_charData.Level.ToString();
                    break;
                case PrimaryAttributes.Experience:
                    m_text.text = "Experience: " + m_charData.Experience.ToString();
                    break;
                case PrimaryAttributes.NextLevelExperience:
                    m_text.text = "Next level at: " + m_charData.NextLevelExperience.ToString();
                    break;
            }
        }
    }

}