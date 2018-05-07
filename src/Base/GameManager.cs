using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MBUnity.Enums;

namespace MBUnity
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            PAUSED,
            SIMULATING
        }

        private static GameManager m_Instance;

        public static GameManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public GameObject locationSceneUI;

        public GameObject locationUI;
        
        public List<Faction> factionList;

        private Text m_yearText;

        private Text m_dayText;

        private Text m_seasonText;

        private GameTime m_gameTime;

        private GameDate m_gameDate;

        private static GameState m_gameState;
        
        private void Awake()
        {
            //Singleton pattern in action
            //Make sure that we only have one instance of this class
            if (m_Instance == null)
                m_Instance = gameObject.GetComponent<GameManager>();
            else
                Destroy(gameObject);

            factionList = new List<Faction>();
            DontDestroyOnLoad(gameObject);

            m_gameTime = new GameTime();
            m_gameDate = new GameDate();

            m_yearText   = GameObject.FindGameObjectWithTag("YearText").GetComponent<Text>();
            m_dayText    = GameObject.FindGameObjectWithTag("DayText").GetComponent<Text>();
            m_seasonText = GameObject.FindGameObjectWithTag("SeasonText").GetComponent<Text>();

            m_gameDate.SetCurrentDay(1);
            m_gameDate.SetCurrentYear(1250);
            m_gameDate.SetCurrentSeason(Season.Spring);

            UpdateDateUI();
        }

        void UpdateDateUI()
        {
            m_yearText.text   = m_gameDate.GetCurrentYear().ToString();
            m_dayText.text    = m_gameDate.GetCurrentDay().ToString() + ",";
            m_seasonText.text = m_gameDate.GetCurrentSeason().ToString();
        }

        private void Update()
        {
            //<summary>
            //This is where we update the time and the date
            //We also update the Date UI based on the values calculated here
            //</summary>
            if (m_gameTime.keepCounting && m_gameState == GameState.SIMULATING)
            {
                if (m_gameTime.GetCurrentTime() > 72)
                {
                    m_gameDate.GoToNextDay();
                    if (m_gameDate.GetCurrentDay() > 90)
                    {
                        if (m_gameDate.GetCurrentSeason() == Season.Winter)
                        {
                            m_gameDate.GoToNextYear();
                        }
                        m_gameDate.SetCurrentSeason(m_gameDate.GetNextSeason());
                        m_gameDate.SetCurrentDay(1);
                    }

                    UpdateDateUI();
                    m_gameTime.SetCurrentTime(1);
                }

                m_gameTime.UpdateTime();
            }
        }

        public GameTime GetGameTime()
        {
            return m_gameTime;
        }

        public void ActivateLocationSceneUI()
        {
            locationSceneUI.SetActive(true);
        }

        public void SetLocationSceneUIData(Location data)
        {
            locationSceneUI.GetComponent<LocationSceneUI>().locationData = data;
        }

        public bool IsPaused()
        {
            if (m_gameState == GameState.PAUSED)
                return true;
            else
                return false;
        }

        public GameState GetState()
        {
            return m_gameState;
        }

        public void SetState(GameState newState)
        {
            m_gameState = newState;
        }

    } 
}
