using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class GameTime
    {
        public bool keepCounting = true;

        private float m_currentTime = 0;

        public void SetCurrentTime(int newTime)
        {
            m_currentTime = newTime;
        }

        public float GetCurrentTime()
        {
            return m_currentTime;
        }

        public float TranslateCurrentTimeToHour()
        {
            return (m_currentTime / 3);
        }
        
        public void UpdateTime()
        {
            m_currentTime += Time.deltaTime;
        }
    }

}