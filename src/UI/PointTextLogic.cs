using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class PointTextLogic : MonoBehaviour
    {
        public Points whichAttribute;

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
            switch (whichAttribute)
            {
                case Points.AttributePoints:
                    m_text.text = "Attribute Points: " + m_charData.AttributePoints;
                    break;
                case Points.SkillPoints:
                    m_text.text = "Skill Points: " + m_charData.SkillPoints;
                    break;
                case Points.WeaponPoints:
                    m_text.text = "Weapon Points: " + m_charData.WeaponPoints;
                    break;
            }
        }
    }

}