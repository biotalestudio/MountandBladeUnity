using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class PartyUI : MonoBehaviour
    {

        public static Party partyData;

        public GameObject partyNameObj;
        public GameObject partySizeObj;
        public GameObject backgroundPanelObj;
        public Text[] partyTexts;


        private bool m_HasFinished = false;
        private bool m_IsPlayer = false;
        private bool m_HasWrittenName = false;
        private bool m_HasWrittenSpeed = false;
        private bool m_HasWrittenFaction = false;
        private bool m_HasWrittenStatus = false;
        private bool m_HasWrittenTroopsText = false;
        private bool m_HasWrittenTroops = false;

        private Color m_currentColor;

        // Use this for initialization
        void Start()
        {

        }

        public void Activate()
        {
            if (partyData.IsPlayer)
            {
                m_IsPlayer = true;
            }

            for (int i = 0; i < partyTexts.Length; i++)
            {
                partyTexts[i].gameObject.SetActive(true);
            }

            backgroundPanelObj.SetActive(true);

        }

        public void Deactivate()
        {
            ResetUI();

            for (int i = 0; i < partyTexts.Length; i++)
            {
                partyTexts[i].gameObject.SetActive(false);
            }

            backgroundPanelObj.SetActive(false);
        }

        void ResetUI()
        {
            m_HasFinished = false;
            m_IsPlayer = false;
            m_HasWrittenName = false;
            m_HasWrittenSpeed = false;
            m_HasWrittenFaction = false;
            m_HasWrittenStatus = false;
            m_HasWrittenTroopsText = false;
            m_HasWrittenTroops = false;
        }

        public string WhatToWrite()
        {
            if (m_IsPlayer && !m_HasWrittenName)
            {
                m_HasWrittenName = true;
                m_currentColor = Color.white;
                return partyData.Leader.Name;
            }
            else if (!m_IsPlayer && !m_HasWrittenName && !partyData.IsBandit)
            {
                m_HasWrittenName = true;
                m_currentColor = partyData.Leader.FactionData.Color;
                return partyData.Leader.Name + "'s Party" + " (" + partyData.Size + ")";
            }
            else if (partyData.IsBandit && !m_HasWrittenName)
            {
                m_HasWrittenName = true;
                m_HasWrittenFaction = true;
                m_currentColor = partyData.Leader.FactionData.Color;
                return partyData.Leader.FactionData.Name + " (" + partyData.Size + " )";
            }
            else if (!m_IsPlayer && !m_HasWrittenFaction)
            {
                m_HasWrittenFaction = true;
                m_currentColor = partyData.Leader.FactionData.Color;
                return "(" + partyData.Leader.FactionData.Name + ")";
            }
            else if (!m_HasWrittenStatus && partyData.FollowingParty != null)
            {
                m_HasWrittenStatus = true;
                m_currentColor = Color.white;
                string text = "Travelling to " + partyData.FollowingParty.Leader.Name + "'s Party";
                return text;
            }
            else if (!m_HasWrittenStatus && partyData.FollowingLocation != null)
            {
                m_HasWrittenStatus = true;
                m_currentColor = Color.white;
                string text = "Travelling to " + partyData.FollowingLocation.Name;
                return text;
            }
            else if (!m_HasWrittenStatus)
            {
                m_HasWrittenStatus = true;
                m_currentColor = Color.white;
                return partyData.CurrentStatus.ToString();
            }
            else if (!m_HasWrittenSpeed && partyData.CurrentStatus != PartyStatus.Holding)
            {
                m_HasWrittenSpeed = true;
                m_currentColor = Color.white;
                return "Speed = " + partyData.Speed;
            }
            else if (!m_HasWrittenTroopsText)
            {
                m_HasWrittenTroopsText = true;
                m_currentColor = Color.white;
                m_HasFinished = true;
                return "TROOPS:";
            }
            else if (!m_HasWrittenTroops)
            {
                m_HasWrittenTroops = true;
                m_currentColor = Color.cyan;
                string str = "";
                foreach (Troop troop in partyData.Troops)
                {
                    str += troop.character.Name + " (" + troop.size + ")\n";
                }
                return str;
            }
            else
            {
                m_currentColor = Color.white;
                return "";
            }
        }

        public Color GetCurrentColor()
        {
            return m_currentColor;
        }
    } 
}
