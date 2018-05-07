using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBUnity.Enums;
using UnityEngine.UI;

namespace MBUnity
{
    public class WeaponMasterTextLogic : MonoBehaviour
    {

        public Proficiencies whichWeaponType;

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
            switch (whichWeaponType)
            {
                case Proficiencies.OneHandedWeapon:
                    m_text.text = "One Handed Weapons: " + m_charData.OneHandedWeapon;
                    break;
                case Proficiencies.TwoHandedWeapon:
                    m_text.text = "Two Handed Weapons: " + m_charData.TwoHandedWeapon;
                    break;
                case Proficiencies.Polearms:
                    m_text.text = "Polearms: " + m_charData.Polearms;
                    break;
                case Proficiencies.Archery:
                    m_text.text = "Archery: " + m_charData.Archery;
                    break;
                case Proficiencies.Crossbow:
                    m_text.text = "Crossbow: " + m_charData.Crossbow;
                    break;
                case Proficiencies.Throwing:
                    m_text.text = "Throwing: " + m_charData.Throwing;
                    break;
            }
        }
    }

}