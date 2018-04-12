using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

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
