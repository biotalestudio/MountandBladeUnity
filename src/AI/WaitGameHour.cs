using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace MBUnity
{
    [TaskIcon("{SkinColor}WaitIcon.png")]
    public class WaitGameHour : Action
    {
        public float hoursToWait;
        public bool randomWait;

        public float randomMinHour;
        public float randomMaxHour;
        
        private float m_currentGameHour;
        private float m_startingHour;

        public override void OnStart()
        {
            m_startingHour = GameManager.Instance.GetGameTime().TranslateCurrentTimeToHour();
            m_currentGameHour = m_startingHour;

            if (randomWait)
            {
                hoursToWait = Random.Range(randomMinHour, randomMaxHour);
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (hoursToWait > (m_currentGameHour - m_startingHour))
            {
                m_currentGameHour = (GameManager.Instance.GetGameTime().TranslateCurrentTimeToHour());
                return TaskStatus.Running;
            }
            else
            {
                Debug.Log("Waiting is finished");
                return TaskStatus.Success;
            }
        }
    } 
}
