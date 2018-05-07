using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class WeaponMasterButtonLogic : MonoBehaviour
    {

        public Proficiencies masteryType;

        private Character m_charData;
        private Image m_image;
        private Button m_button;

        // Use this for initialization
        void Start()
        {
            m_image = GetComponent<Image>();
            m_button = GetComponent<Button>();
            m_charData = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().charData;
        }

        public void ApplyStats()
        {
            switch (masteryType)
            {
                case Proficiencies.OneHandedWeapon:
                    m_charData.OneHandedWeapon++;
                    m_charData.WeaponPoints--;
                    break;
                case Proficiencies.TwoHandedWeapon:
                    m_charData.TwoHandedWeapon++;
                    m_charData.WeaponPoints--; ;
                    break;
                case Proficiencies.Polearms:
                    m_charData.Polearms++;
                    m_charData.WeaponPoints--;
                    break;
                case Proficiencies.Archery:
                    m_charData.Archery++;
                    m_charData.WeaponPoints--;
                    break;
                case Proficiencies.Crossbow:
                    m_charData.Crossbow++;
                    m_charData.WeaponPoints--;
                    break;
                case Proficiencies.Throwing:
                    m_charData.Throwing++;
                    m_charData.WeaponPoints--;
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {

            switch (masteryType)
            {
                case Proficiencies.OneHandedWeapon:
                    if (m_charData.WeaponPoints > 0)
                    {
                        m_image.enabled = true;
                        m_image.enabled = true;
                    }
                    else
                    {
                        m_image.enabled = false;
                        m_image.enabled = false;
                    }
                    break;
                case Proficiencies.TwoHandedWeapon:
                    if (m_charData.WeaponPoints > 0)
                    {
                        m_image.enabled = true;
                        m_image.enabled = true;
                    }
                    else
                    {
                        m_image.enabled = false;
                        m_image.enabled = false;
                    }
                    break;
                case Proficiencies.Polearms:
                    if (m_charData.WeaponPoints > 0)
                    {
                        m_image.enabled = true;
                        m_image.enabled = true;
                    }
                    else
                    {
                        m_image.enabled = false;
                        m_image.enabled = false;
                    }
                    break;
                case Proficiencies.Archery:
                    if (m_charData.WeaponPoints > 0)
                    {
                        m_image.enabled = true;
                        m_image.enabled = true;
                    }
                    else
                    {
                        m_image.enabled = false;
                        m_image.enabled = false;
                    }
                    break;
                case Proficiencies.Crossbow:
                    if (m_charData.WeaponPoints > 0)
                    {
                        m_image.enabled = true;
                        m_image.enabled = true;
                    }
                    else
                    {
                        m_image.enabled = false;
                        m_image.enabled = false;
                    }
                    break;
                case Proficiencies.Throwing:
                    if (m_charData.WeaponPoints > 0)
                    {
                        m_image.enabled = true;
                        m_image.enabled = true;
                    }
                    else
                    {
                        m_image.enabled = false;
                        m_image.enabled = false;
                    }
                    break;


            }

        }
    }

}