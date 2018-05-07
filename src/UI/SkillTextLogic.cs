using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class SkillTextLogic : MonoBehaviour
    {

        public Skills whichAttribute;


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
                case Skills.Ironflesh:
                    m_text.text = m_charData.Ironflesh.ToString();
                    break;
                case Skills.PowerStrike:
                    m_text.text = m_charData.PowerStrike.ToString();
                    break;
                case Skills.PowerThrow:
                    m_text.text = m_charData.PowerThrow.ToString();
                    break;
                case Skills.PowerDraw:
                    m_text.text = m_charData.PowerDraw.ToString();
                    break;
                case Skills.WeaponMaster:
                    m_text.text = m_charData.WeaponMaster.ToString();
                    break;
                case Skills.Shield:
                    m_text.text = m_charData.Shield.ToString();
                    break;
                case Skills.Athletics:
                    m_text.text = m_charData.Athletics.ToString();
                    break;
                case Skills.Riding:
                    m_text.text = m_charData.Riding.ToString();
                    break;
                case Skills.HorseArchery:
                    m_text.text = m_charData.HorseArchery.ToString();
                    break;
                case Skills.Looting:
                    m_text.text = m_charData.Looting.ToString();
                    break;
                case Skills.Trainer:
                    m_text.text = m_charData.Trainer.ToString();
                    break;
                case Skills.Tracking:
                    m_text.text = m_charData.Tracking.ToString();
                    break;
                case Skills.Tactics:
                    m_text.text = m_charData.Tactics.ToString();
                    break;
                case Skills.PathFinding:
                    m_text.text = m_charData.PathFinding.ToString();
                    break;
                case Skills.Spotting:
                    m_text.text = m_charData.Spotting.ToString();
                    break;
                case Skills.InventoryManagement:
                    m_text.text = m_charData.InventoryManagement.ToString();
                    break;
                case Skills.WoundTreatment:
                    m_text.text = m_charData.WoundTreatment.ToString();
                    break;
                case Skills.Surgery:
                    m_text.text = m_charData.Surgery.ToString();
                    break;
                case Skills.FirstAid:
                    m_text.text = m_charData.FirstAid.ToString();
                    break;
                case Skills.Engineer:
                    m_text.text = m_charData.Engineer.ToString();
                    break;
                case Skills.Persuasion:
                    m_text.text = m_charData.Persuasion.ToString();
                    break;
                case Skills.PrisonerManagement:
                    m_text.text = m_charData.PrisonerManagement.ToString();
                    break;
                case Skills.Leadership:
                    m_text.text = m_charData.Leadership.ToString();
                    break;
                case Skills.Trade:
                    m_text.text = m_charData.Trade.ToString();
                    break;
            }
        }
    } 
}
