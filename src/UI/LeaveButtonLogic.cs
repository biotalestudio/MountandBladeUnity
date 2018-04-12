using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveButtonLogic : MonoBehaviour
{

    public GameObject locationSceneUI;

	// Use this for initialization
	public void DisableLocationSceneUI()
    {
        locationSceneUI.SetActive(false);
        GameManager.Instance.SetState(GameManager.GameState.SIMULATING);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
