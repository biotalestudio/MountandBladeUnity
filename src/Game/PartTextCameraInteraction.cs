using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTextCameraInteraction : MonoBehaviour {

    private GameObject m_mainCamera;

	// Use this for initialization
	void Start ()
    {
        m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 textRot = transform.rotation.eulerAngles;
        Vector3 rotDir = new Vector3(m_mainCamera.transform.rotation.eulerAngles.x, m_mainCamera.transform.rotation.eulerAngles.y, textRot.z);
        transform.rotation = Quaternion.Euler(rotDir);
    }
}
