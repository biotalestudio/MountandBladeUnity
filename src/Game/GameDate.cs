using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter,
        INVALID
    };

    public class GameDate
    {
        private Season m_currenSeason;
        private int m_currentYear;
        private int m_currentDay;

        public Season GetCurrentSeason()
        {
            return m_currenSeason;
        }

        public void SetCurrentSeason(Season newSeason)
        {
            m_currenSeason = newSeason;
        }

        public int GetCurrentYear()
        {
            return m_currentYear;
        }

        public void SetCurrentYear(int newYear)
        {
            m_currentYear = newYear;
        }

        public void GoToNextYear()
        {
            m_currentYear++;
        }

        public int GetCurrentDay()
        {
            return m_currentDay;
        }

        public void SetCurrentDay(int newDay)
        {
            m_currentDay = newDay;
        }

        public void GoToNextDay()
        {
            m_currentDay++;
        }

        public Season GetNextSeason()
        {
            if (m_currenSeason == Season.Spring)
                return Season.Summer;
            else if (m_currenSeason == Season.Summer)
                return Season.Autumn;
            else if (m_currenSeason == Season.Autumn)
                return Season.Winter;
            else if (m_currenSeason == Season.Winter)
                return Season.Spring;
            else
            {
                Debug.LogWarning("INVALID SEASON RETURN");
                return Season.INVALID;
            }
        }
    }

}