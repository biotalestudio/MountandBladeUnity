using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class SkillPointButtonLogic : MonoBehaviour
    {
        public Attributes baseAttribute;
        public Skills whichSkill;

        private Button m_button;
        private Image m_image;
        private Character m_charData;

        // Use this for initialization
        void Start()
        {
            m_charData = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().charData;
            m_button = GetComponent<Button>();
            m_image = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckAvaibility();
        }

        public void ApplyStats()
        {
            Debug.Log("Applied");
            switch (whichSkill)
            {
                case Skills.Ironflesh:
                    m_charData.Ironflesh++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.PowerStrike:
                    m_charData.PowerStrike++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.PowerThrow:
                    m_charData.PowerThrow++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.PowerDraw:
                    m_charData.PowerDraw++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.WeaponMaster:
                    m_charData.WeaponMaster++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Shield:
                    m_charData.Shield++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Athletics:
                    m_charData.Athletics++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Riding:
                    m_charData.Riding++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.HorseArchery:
                    m_charData.HorseArchery++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Looting:
                    m_charData.Looting++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Trainer:
                    m_charData.Trainer++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Tracking:
                    m_charData.Tracking++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Tactics:
                    m_charData.Tactics++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.PathFinding:
                    m_charData.PathFinding++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Spotting:
                    m_charData.Spotting++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.InventoryManagement:
                    m_charData.InventoryManagement++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.WoundTreatment:
                    m_charData.WoundTreatment++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Surgery:
                    m_charData.Surgery++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.FirstAid:
                    m_charData.FirstAid++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Engineer:
                    m_charData.Engineer++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Persuasion:
                    m_charData.Persuasion++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.PrisonerManagement:
                    m_charData.PrisonerManagement++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Leadership:
                    m_charData.Leadership++;
                    m_charData.SkillPoints--;
                    break;
                case Skills.Trade:
                    m_charData.Trade++;
                    m_charData.SkillPoints--;
                    break;
            }
        }

        void CheckAvaibility()
        {
            switch (baseAttribute)
            {
                case Attributes.Strength:
                    int strLimitValue = m_charData.Strength / 3;

                    switch (whichSkill)
                    {
                        case Skills.Ironflesh:
                            if (strLimitValue > m_charData.Ironflesh && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.PowerStrike:
                            if (strLimitValue > m_charData.PowerStrike && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.PowerThrow:
                            if (strLimitValue > m_charData.PowerThrow && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.PowerDraw:
                            if (strLimitValue > m_charData.PowerDraw && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                    }
                    break;
                case Attributes.Agility:
                    int agiLimitValue = m_charData.Agility / 3;

                    switch (whichSkill)
                    {
                        case Skills.WeaponMaster:
                            if (agiLimitValue > m_charData.WeaponMaster && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Shield:
                            if (agiLimitValue > m_charData.Shield && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Athletics:
                            if (agiLimitValue > m_charData.Athletics && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Riding:
                            if (agiLimitValue > m_charData.Riding && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.HorseArchery:
                            if (agiLimitValue > m_charData.Riding && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Looting:
                            if (agiLimitValue > m_charData.Looting && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                    }
                    break;
                case Attributes.Intelligence:
                    int intLimitValue = m_charData.Intelligence / 3;
                    switch (whichSkill)
                    {
                        case Skills.Trainer:
                            if (intLimitValue > m_charData.Looting && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Tracking:
                            if (intLimitValue > m_charData.Tracking && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Tactics:
                            if (intLimitValue > m_charData.Tactics && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.PathFinding:
                            if (intLimitValue > m_charData.PathFinding && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Spotting:
                            if (intLimitValue > m_charData.Spotting && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.InventoryManagement:
                            if (intLimitValue > m_charData.InventoryManagement && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.WoundTreatment:
                            if (intLimitValue > m_charData.WoundTreatment && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Surgery:
                            if (intLimitValue > m_charData.Surgery && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.FirstAid:
                            if (intLimitValue > m_charData.FirstAid && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Engineer:
                            if (intLimitValue > m_charData.Engineer && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Persuasion:
                            if (intLimitValue > m_charData.Persuasion && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                    }
                    break;
                case Attributes.Charisma:
                    int chaLimitValue = m_charData.Charisma / 3;

                    switch (whichSkill)
                    {
                        case Skills.PrisonerManagement:
                            if (chaLimitValue > m_charData.PrisonerManagement && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Leadership:
                            if (chaLimitValue > m_charData.Leadership && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                        case Skills.Trade:
                            if (chaLimitValue > m_charData.Trade && m_charData.SkillPoints > 0)
                            {
                                m_button.enabled = true;
                                m_image.enabled = true;
                            }
                            else
                            {
                                m_button.enabled = false;
                                m_image.enabled = false;
                            }
                            break;
                    }

                    break;
            }
        }
    }

}
