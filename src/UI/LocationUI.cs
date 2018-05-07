using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class LocationUI : MonoBehaviour
    {

        public static Location LocationData;

        public Text[] locationTexts;
        public GameObject panel;
        private GameObject m_player;

        private Color m_currentColor;

        private bool m_hasWrittenName;
        private bool m_hasWrittenFactionName;
        private bool m_hasWrittenGarrison;
        private bool m_hasWrittenTroops;
        private bool m_hasWrittenParties;

        private float distance;

        private void Start()
        {
            m_player = GameObject.FindGameObjectWithTag("Player");
        }

        public void Activate()
        {
            if (LocationData.Parties.Count <= 0)
            {
                m_hasWrittenParties = true;
            }

            for (int i = 0; i < locationTexts.Length; i++)
            {
                locationTexts[i].gameObject.SetActive(true);
            }

            panel.SetActive(true);
        }

        public void Deactivate()
        {
            for (int i = 0; i < locationTexts.Length; i++)
            {
                locationTexts[i].gameObject.SetActive(false);
            }
            panel.SetActive(false);

            m_hasWrittenName = false;
            m_hasWrittenFactionName = false;
            m_hasWrittenTroops = false;
            m_hasWrittenGarrison = false;
            m_hasWrittenParties = false;
        }

        public string WhatToWrite()
        {
            distance = Vector3.Distance(LocationData.position, m_player.transform.position);

            if (!m_hasWrittenName && LocationData.Type != Enums.LocationType.Village)
            {
                string str = "";
                str = LocationData.Name + " (" + LocationData.GarrisonSize + ")";
                m_currentColor = LocationData.Ruler.FactionData.Color;
                m_hasWrittenName = true;
                return str;
            }
            else if (!m_hasWrittenName && LocationData.Type == Enums.LocationType.Village)
            {
                string str = "";
                str = LocationData.Name;
                m_currentColor = LocationData.Ruler.FactionData.Color;
                m_hasWrittenName = true;
                return str;
            }
            else if (!m_hasWrittenParties)
            {
                string str = "";
                m_currentColor = LocationData.Ruler.FactionData.Color;
                m_hasWrittenParties = true;

                foreach (Party party in LocationData.Parties)
                {
                    str += party.Leader.Name + "'s Party" + " (" + party.Size + ")\n";
                }
                return str;
            }
            else if (!(LocationData.Type == Enums.LocationType.Village) && !m_hasWrittenFactionName)
            {
                m_currentColor = LocationData.Ruler.FactionData.Color;
                m_hasWrittenFactionName = true;
                return "(" + LocationData.Ruler.FactionData.Name + ")";
            }
            else if (!m_hasWrittenTroops && LocationData.Type != Enums.LocationType.Village)
            {
                m_currentColor = Color.white;
                m_hasWrittenTroops = true;
                string str = "TROOPS: \n";
                return str;
            }
            else if (!m_hasWrittenGarrison && LocationData.Type != Enums.LocationType.Village)
            {
                string str = "";
                m_currentColor = Color.cyan;
                foreach (Troop troop in LocationData.Garrison)
                {
                    str += troop.character.Name + " (" + troop.size + ")\n";
                }
                m_hasWrittenGarrison = true;
                return str;
            }
            else
            {
                return "";
            }
        }

        public Color GetColor()
        {
            return m_currentColor;
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
