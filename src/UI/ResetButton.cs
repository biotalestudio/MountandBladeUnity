using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class ResetButton : MonoBehaviour
    {

        private Character m_tempCharData;

        private Character m_charData;

        void Awake()
        {
            m_charData = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().charData;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Level = m_charData.Level;
            //m_tempCharData.Experience = m_charData.Experience;
            //m_tempCharData.NextLevelExperience = m_charData.NextLevelExperience;
            //m_tempCharData.Strength = m_charData.Strength;
            //m_tempCharData.Agility = m_charData.Agility;
            //m_tempCharData.Intelligence = m_charData.Intelligence;
            //m_tempCharData.Charisma = m_charData.Charisma;
            //m_tempCharData.C = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;
            //m_tempCharData.Age = m_charData.Age;

        }

        public void ResetStats()
        {
            Debug.Log("TempData STR: " + m_tempCharData.Strength);
            Debug.Log("CharData STR: " + m_charData.Strength);
            m_charData = m_tempCharData;
            Debug.Log("TempData STR: " + m_tempCharData.Strength);
            Debug.Log("CharData STR: " + m_charData.Strength);
        }
    }

}